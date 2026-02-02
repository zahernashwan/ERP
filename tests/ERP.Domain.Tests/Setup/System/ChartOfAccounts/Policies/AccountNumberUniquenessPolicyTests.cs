using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.ChartOfAccounts;
using ERP.Domain.Setup.System.ChartOfAccounts.Account;
using ERP.Domain.Setup.System.ChartOfAccounts.Policies;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.ChartOfAccounts.Policies;

public sealed class AccountNumberUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var chartId = ChartOfAccountsId.New();
        var candidate = AccountNumber.From("100");
        IReadOnlyCollection<AccountNumber> existing = [AccountNumber.From("100")];

        Assert.Throws<InvalidChartOfAccountsException>((Action)(() =>
            AccountNumberUniquenessPolicy.EnsureUnique(chartId, candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var chartId = ChartOfAccountsId.New();
        var candidate = AccountNumber.From("200");
        IReadOnlyCollection<AccountNumber> existing = [AccountNumber.From("100")];

        AccountNumberUniquenessPolicy.EnsureUnique(chartId, candidate, existing);
    }
}
