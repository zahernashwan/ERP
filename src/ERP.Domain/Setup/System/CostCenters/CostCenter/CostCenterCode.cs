using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.CostCenters.CostCenter;

public sealed class CostCenterCode : ValueObject
{
    public string Value { get; }

    private CostCenterCode(string value)
    {
        Value = value;
    }

    public static CostCenterCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidCostCenterException("Cost center code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 2)
            throw new InvalidCostCenterException("Cost center code is too short.");

        if (normalized.Length > 16)
            throw new InvalidCostCenterException("Cost center code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                throw new InvalidCostCenterException("Cost center code contains invalid characters.");
        }

        return new CostCenterCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
