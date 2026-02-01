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
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (number is null)
        {
            throw new ArgumentNullException(nameof(number));
        }

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        return new Account(id, number, name, type);
    }

    internal void Rename(AccountName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    internal void ChangeNumber(AccountNumber number)
    {
        Number = number ?? throw new ArgumentNullException(nameof(number));
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

public sealed class InvalidAccountException : DomainException
{
    public InvalidAccountException(string message) : base(message)
    {
    }
}
