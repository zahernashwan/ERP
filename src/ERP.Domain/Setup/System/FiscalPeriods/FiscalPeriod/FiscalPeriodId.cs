namespace ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod;

public sealed class FiscalPeriodId : ValueObject
{
    public Guid Value { get; }

    private FiscalPeriodId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Fiscal period id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static FiscalPeriodId New() => new(Guid.NewGuid());

    public static FiscalPeriodId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
