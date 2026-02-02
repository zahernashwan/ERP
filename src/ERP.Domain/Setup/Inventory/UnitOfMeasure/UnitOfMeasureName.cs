using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.UnitOfMeasure;

public sealed class UnitOfMeasureName : ValueObject
{
    public string Value { get; }

    private UnitOfMeasureName(string value)
    {
        Value = value;
    }

    public static UnitOfMeasureName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidUnitOfMeasureException("Unit of measure name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidUnitOfMeasureException("Unit of measure name is too short.");

        if (normalized.Length > 120)
            throw new InvalidUnitOfMeasureException("Unit of measure name is too long.");

        return new UnitOfMeasureName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
