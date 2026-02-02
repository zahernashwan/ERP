using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Company;

public sealed class CompanyName : ValueObject
{
    public string Value { get; }

    private CompanyName(string value)
    {
        Value = value;
    }

    public static CompanyName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidCompanyException("Company name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidCompanyException("Company name is too short.");

        if (normalized.Length > 120)
            throw new InvalidCompanyException("Company name is too long.");

        return new CompanyName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
