using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.UnitOfMeasure;

public sealed class UnitOfMeasureCode : ValueObject
{
    public string Value { get; }

    private UnitOfMeasureCode(string value)
    {
        Value = value;
    }

    public static UnitOfMeasureCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidUnitOfMeasureException("Unit of measure code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 1)
            throw new InvalidUnitOfMeasureException("Unit of measure code is required.");

        if (normalized.Length > 10)
            throw new InvalidUnitOfMeasureException("Unit of measure code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            if (!char.IsLetterOrDigit(normalized[i]))
                throw new InvalidUnitOfMeasureException("Unit of measure code must contain letters and digits only.");
        }

        return new UnitOfMeasureCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
