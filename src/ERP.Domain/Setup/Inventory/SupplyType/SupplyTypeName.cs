using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.SupplyType;

public sealed class SupplyTypeName : ValueObject
{
    public string Value { get; }

    private SupplyTypeName(string value)
    {
        Value = value;
    }

    public static SupplyTypeName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidSupplyTypeException("Supply type name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidSupplyTypeException("Supply type name is too short.");

        if (normalized.Length > 120)
            throw new InvalidSupplyTypeException("Supply type name is too long.");

        return new SupplyTypeName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
