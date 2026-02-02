using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.ChartOfAccounts;
using ERP.Domain.Setup.System.ChartOfAccounts.Account;
using ChartOfAccountsAggregate = ERP.Domain.Setup.System.ChartOfAccounts.ChartOfAccounts;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.ChartOfAccounts;

public sealed class ChartOfAccountsTests
{
    [Fact]
    public void AddAccount_WhenDuplicateNumber_Throws()
    {
        var chart = ChartOfAccountsAggregate.Create(ChartOfAccountsId.New(), ChartName.From("Main"));

        chart.AddAccount(
            AccountId.New(),
            AccountNumber.From("100"),
            AccountName.From("Cash"),
            AccountType.Asset,
            parentAccountId: null);

        Assert.Throws<InvalidChartOfAccountsException>((Action)(() =>
            chart.AddAccount(
                AccountId.New(),
                AccountNumber.From("100"),
                AccountName.From("Cash 2"),
                AccountType.Asset,
                parentAccountId: null)));
    }

    [Fact]
    public void AddAccount_WhenParentMissing_Throws()
    {
        var chart = ChartOfAccountsAggregate.Create(ChartOfAccountsId.New(), ChartName.From("Main"));

        Assert.Throws<InvalidChartOfAccountsException>((Action)(() =>
            chart.AddAccount(
                AccountId.New(),
                AccountNumber.From("200"),
                AccountName.From("Child"),
                AccountType.Asset,
                parentAccountId: AccountId.New())));
    }

    [Fact]
    public void AddAccount_WhenParentInactive_Throws()
    {
        var chart = ChartOfAccountsAggregate.Create(ChartOfAccountsId.New(), ChartName.From("Main"));

        var parentId = AccountId.New();

        chart.AddAccount(
            parentId,
            AccountNumber.From("100"),
            AccountName.From("Parent"),
            AccountType.Asset,
            parentAccountId: null);

        var parentAccount = chart.Accounts.Single(a => a.Id.Equals(parentId));
        parentAccount.Deactivate(hasChildren: false);

        Assert.Throws<InvalidChartOfAccountsException>((Action)(() =>
            chart.AddAccount(
                AccountId.New(),
                AccountNumber.From("110"),
                AccountName.From("Child"),
                AccountType.Asset,
                parentAccountId: parentId)));
    }
}
