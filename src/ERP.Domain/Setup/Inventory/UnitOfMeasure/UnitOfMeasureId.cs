namespace ERP.Domain.Setup.Inventory.UnitOfMeasure;

public sealed class UnitOfMeasureId : ValueObject
{
    public Guid Value { get; }

    private UnitOfMeasureId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Unit of measure id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static UnitOfMeasureId New() => new(Guid.NewGuid());

    public static UnitOfMeasureId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
