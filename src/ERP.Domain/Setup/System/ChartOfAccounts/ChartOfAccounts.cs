using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.ChartOfAccounts.Account;
using AccountEntity = ERP.Domain.Setup.System.ChartOfAccounts.Account.Account;

namespace ERP.Domain.Setup.System.ChartOfAccounts;

public sealed class ChartOfAccounts : Entity<ChartOfAccountsId>
{
    private readonly List<AccountEntity> _accounts = [];

    private ChartOfAccounts(ChartOfAccountsId id, ChartName name, bool isActive)
        : base(id)
    {
        Name = name;
        IsActive = isActive;
    }

    public ChartName Name { get; private set; }
    public bool IsActive { get; private set; }

    public IReadOnlyCollection<AccountEntity> Accounts => _accounts.AsReadOnly();

    public static ChartOfAccounts Create(ChartOfAccountsId id, ChartName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(name);

        return new ChartOfAccounts(id, name, isActive: true);
    }

    public AccountEntity AddAccount(
        AccountId id,
        AccountNumber number,
        AccountName name,
        AccountType type,
        AccountId? parentAccountId)
    {
        EnsureActive();

        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(name);

        if (_accounts.Any(a => a.Number.Equals(number)))
            throw new InvalidChartOfAccountsException("Account number must be unique within the chart.");

        if (parentAccountId is not null)
        {
            var parent = _accounts.SingleOrDefault(a => a.Id.Equals(parentAccountId));
            if (parent is null || !parent.IsActive)
                throw new InvalidChartOfAccountsException("Parent account must exist within the chart and be active.");
        }

        var account = AccountEntity.Create(id, number, name, type, parentAccountId);
        _accounts.Add(account);
        return account;
    }

    public void Rename(ChartName name)
    {
        EnsureActive();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void Deactivate()
    {
        EnsureActive();
        IsActive = false;
    }

    private void EnsureActive()
    {
        if (!IsActive)
            throw new InvalidChartOfAccountsException("Inactive chart of accounts cannot be modified.");
    }
}
