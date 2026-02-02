using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.SupplyType;

public sealed class SupplyTypeCode : ValueObject
{
    public string Value { get; }

    private SupplyTypeCode(string value)
    {
        Value = value;
    }

    public static SupplyTypeCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidSupplyTypeException("Supply type code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 2)
            throw new InvalidSupplyTypeException("Supply type code is too short.");

        if (normalized.Length > 10)
            throw new InvalidSupplyTypeException("Supply type code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                throw new InvalidSupplyTypeException("Supply type code contains invalid characters.");
        }

        return new SupplyTypeCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
