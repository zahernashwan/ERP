using ERP.Domain.Accounting.Aggregates.Accounts;
using ERP.Domain.Accounting.Events;
using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Aggregates.ChartOfAccounts;

public sealed class ChartOfAccounts : Entity<ChartOfAccountsId>
{
    private readonly List<Account> _accounts = new();
    private readonly List<DomainEvent> _domainEvents = new();

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
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new ChartOfAccounts(id, name);
    }

    public Account RegisterAccount(AccountNumber number, AccountName name, AccountType type)
    {
        EnsureOpen();

        if (number is null)
        {
            throw new ArgumentNullException(nameof(number));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

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

        if (number is null)
        {
            throw new ArgumentNullException(nameof(number));
        }

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
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void Close()
    {
        EnsureOpen();
        Status = ChartStatus.Closed;
    }

    private Account FindAccount(AccountId accountId)
    {
        if (accountId is null)
        {
            throw new ArgumentNullException(nameof(accountId));
        }

        var account = _accounts.SingleOrDefault(item => item.Id.Equals(accountId));
        if (account is null)
        {
            throw new AccountNotFoundException("Account is not part of this chart.");
        }

        return account;
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
