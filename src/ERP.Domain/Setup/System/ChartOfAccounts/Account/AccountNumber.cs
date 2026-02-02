using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.ChartOfAccounts.Account;

public sealed class AccountNumber : ValueObject
{
    public string Value { get; }

    private AccountNumber(string value)
    {
        Value = value;
    }

    public static AccountNumber From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidAccountException("Account number is required.");

        var normalized = value.Trim();

        if (normalized.Length < 1)
            throw new InvalidAccountException("Account number is required.");

        if (normalized.Length > 32)
            throw new InvalidAccountException("Account number is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsDigit(ch) && ch != '.' && ch != '-')
                throw new InvalidAccountException("Account number contains invalid characters.");
        }

        return new AccountNumber(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
