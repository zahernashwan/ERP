namespace ERP.Domain.Setup.System.CostCenters.CostCenter;

public sealed class CostCenterId : ValueObject
{
    public Guid Value { get; }

    private CostCenterId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Cost center id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static CostCenterId New() => new(Guid.NewGuid());

    public static CostCenterId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
