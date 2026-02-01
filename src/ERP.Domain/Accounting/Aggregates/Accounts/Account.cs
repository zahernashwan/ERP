using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Aggregates.Accounts;

public sealed class Account : Entity<AccountId>
{
    private Account(AccountId id, AccountNumber number, string name, AccountType type)
        : base(id)
    {
        Number = number;
        Name = name;
        Type = type;
        IsActive = true;
    }

    public AccountNumber Number { get; private set; }
    public string Name { get; private set; }
    public AccountType Type { get; private set; }
    public bool IsActive { get; private set; }

    public static Account Open(AccountId id, AccountNumber number, string name, AccountType type)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (number is null)
        {
            throw new ArgumentNullException(nameof(number));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidAccountException("Account name is required.");
        }

        return new Account(id, number, name.Trim(), type);
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidAccountException("Account name is required.");
        }

        Name = name.Trim();
    }

    public void ChangeNumber(AccountNumber number)
    {
        Number = number ?? throw new ArgumentNullException(nameof(number));
    }

    public void Deactivate() => IsActive = false;

    public void Activate() => IsActive = true;
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
