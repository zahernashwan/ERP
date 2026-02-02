using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.ChartOfAccounts.Account;

public sealed class AccountName : ValueObject
{
    public string Value { get; }

    private AccountName(string value)
    {
        Value = value;
    }

    public static AccountName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidAccountException("Account name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidAccountException("Account name is too short.");

        if (normalized.Length > 120)
            throw new InvalidAccountException("Account name is too long.");

        return new AccountName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
