using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Aggregates.Accounts;

public sealed class Account : Entity<AccountId>
{
    private Account(AccountId id, AccountNumber number, AccountName name, AccountType type)
        : base(id)
    {
        Number = number;
        Name = name;
        Type = type;
        IsActive = true;
    }

    public AccountNumber Number { get; private set; }
    public AccountName Name { get; private set; }
    public AccountType Type { get; private set; }
    public bool IsActive { get; private set; }

    internal static Account Create(AccountId id, AccountNumber number, AccountName name, AccountType type)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(number);
        ArgumentNullException.ThrowIfNull(name);

        return new Account(id, number, name, type);
    }

    internal void Rename(AccountName name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    internal void ChangeNumber(AccountNumber number)
    {
        ArgumentNullException.ThrowIfNull(number);
        Number = number;
    }

    internal void Deactivate() => IsActive = false;

    internal void Activate() => IsActive = true;
}

public enum AccountType
{
    Asset,
    Liability,
    Equity,
    Revenue,
    Expense
}
