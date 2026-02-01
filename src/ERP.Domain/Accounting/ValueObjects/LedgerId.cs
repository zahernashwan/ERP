namespace ERP.Domain.Accounting.ValueObjects;

public sealed class LedgerId : ValueObject
{
    public Guid Value { get; }

    private LedgerId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Ledger id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static LedgerId New() => new(Guid.NewGuid());

    public static LedgerId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
