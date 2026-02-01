namespace ERP.Domain.Accounting.ValueObjects;

public sealed class JournalNumber : ValueObject
{
    public string Value { get; }

    private JournalNumber(string value)
    {
        Value = value;
    }

    public static JournalNumber From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Journal number is required.", nameof(value));
        }

        return new JournalNumber(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
