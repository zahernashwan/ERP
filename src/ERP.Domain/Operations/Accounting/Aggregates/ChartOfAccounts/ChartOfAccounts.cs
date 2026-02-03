using ERP.Domain.Operations.Accounting.Events;
using ERP.Domain.Operations.Accounting.Exceptions;
using ERP.Domain.Operations.Accounting.Aggregates.Accounts;
using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Domain.Operations.Accounting.Aggregates.ChartOfAccounts;

public sealed class ChartOfAccounts : Entity<ChartOfAccountsId>
{
    private readonly List<Account> _accounts = [];
    private readonly List<DomainEvent> _domainEvents = [];

    private ChartOfAccounts(ChartOfAccountsId id, ChartName name)
        : base(id)
    {
        Name = name;
        Status = ChartStatus.Open;
        _domainEvents.Add(new ChartOpened(id));
    }

    public ChartName Name { get; private set; }
    public ChartStatus Status { get; private set; }
    public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public static ChartOfAccounts Open(ChartOfAccountsId id, ChartName name)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(name);

        return new ChartOfAccounts(id, name);
    }

    public Account RegisterAccount(AccountNumber number, AccountName name, AccountType type)
    {
        EnsureOpen();

        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(name);

        if (_accounts.Any(account => account.Number.Equals(number)))
        {
            throw new DuplicateAccountNumberException("Account number must be unique within the chart.");
        }

        var account = Account.Create(AccountId.New(), number, name, type);
        _accounts.Add(account);
        _domainEvents.Add(new AccountRegistered(account.Id, account.Number));
        return account;
    }

    public void RenameAccount(AccountId accountId, AccountName name)
    {
        EnsureOpen();
        var account = FindAccount(accountId);
        account.Rename(name);
    }

    public void ChangeAccountNumber(AccountId accountId, AccountNumber number)
    {
        EnsureOpen();

        ArgumentNullException.ThrowIfNull(number);

        if (_accounts.Any(account => account.Number.Equals(number)))
        {
            throw new DuplicateAccountNumberException("Account number must be unique within the chart.");
        }

        var account = FindAccount(accountId);
        account.ChangeNumber(number);
    }

    public void DeactivateAccount(AccountId accountId)
    {
        EnsureOpen();
        var account = FindAccount(accountId);
        account.Deactivate();
        _domainEvents.Add(new AccountDeactivated(account.Id));
    }

    public void ActivateAccount(AccountId accountId)
    {
        EnsureOpen();
        var account = FindAccount(accountId);
        account.Activate();
    }

    public void Rename(ChartName name)
    {
        EnsureOpen();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public void Close()
    {
        EnsureOpen();
        Status = ChartStatus.Closed;
    }

    private Account FindAccount(AccountId accountId)
    {
        ArgumentNullException.ThrowIfNull(accountId);

        return _accounts.SingleOrDefault(item => item.Id.Equals(accountId))
            ?? throw new AccountNotFoundException("Account is not part of this chart.");
    }

    private void EnsureOpen()
    {
        if (Status != ChartStatus.Open)
        {
            throw new ChartClosedException("Chart of accounts is closed.");
        }
    }
}

public enum ChartStatus
{
    Open,
    Closed
}
