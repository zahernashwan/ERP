namespace ERP.Domain.Setup.Inventory.SupplyType;

public sealed class SupplyTypeId : ValueObject
{
    public Guid Value { get; }

    private SupplyTypeId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Supply type id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static SupplyTypeId New() => new(Guid.NewGuid());

    public static SupplyTypeId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
