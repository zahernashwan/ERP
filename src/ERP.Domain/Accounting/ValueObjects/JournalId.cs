namespace ERP.Domain.Accounting.ValueObjects;

public sealed class JournalId : ValueObject
{
    public Guid Value { get; }

    private JournalId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Journal id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static JournalId New() => new(Guid.NewGuid());

    public static JournalId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
