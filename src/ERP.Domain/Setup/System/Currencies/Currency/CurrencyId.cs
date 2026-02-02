namespace ERP.Domain.Setup.System.Currencies.Currency;

public sealed class CurrencyId : ValueObject
{
    public Guid Value { get; }

    private CurrencyId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Currency id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static CurrencyId New() => new(Guid.NewGuid());

    public static CurrencyId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
