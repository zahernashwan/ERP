namespace ERP.Domain.Accounting.ValueObjects;

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
        {
            throw new ArgumentException("Account number is required.", nameof(value));
        }

        return new AccountNumber(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
