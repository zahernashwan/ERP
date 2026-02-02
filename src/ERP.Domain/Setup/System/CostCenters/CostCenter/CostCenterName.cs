using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.CostCenters.CostCenter;

public sealed class CostCenterName : ValueObject
{
    public string Value { get; }

    private CostCenterName(string value)
    {
        Value = value;
    }

    public static CostCenterName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidCostCenterException("Cost center name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidCostCenterException("Cost center name is too short.");

        if (normalized.Length > 120)
            throw new InvalidCostCenterException("Cost center name is too long.");

        return new CostCenterName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
