using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.ChartOfAccounts;

public sealed class ChartName : ValueObject
{
    public string Value { get; }

    private ChartName(string value)
    {
        Value = value;
    }

    public static ChartName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidChartOfAccountsException("Chart name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidChartOfAccountsException("Chart name is too short.");

        if (normalized.Length > 80)
            throw new InvalidChartOfAccountsException("Chart name is too long.");

        return new ChartName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
