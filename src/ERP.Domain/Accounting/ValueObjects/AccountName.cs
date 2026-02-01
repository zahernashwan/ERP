namespace ERP.Domain.Accounting.ValueObjects;

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
        {
            throw new ArgumentException("Account name is required.", nameof(value));
        }

        return new AccountName(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
