namespace ERP.Domain.Accounting.ValueObjects;

public sealed class ChartName : ValueObject
{
    public string Value { get; }

    private ChartName(string value)
    {
        Value = value;
    }

    public static ChartName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Chart name is required.", nameof(value));
        }

        return new ChartName(value.Trim());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
