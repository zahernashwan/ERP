using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Company;

public sealed class TaxRegistrationNumber : ValueObject
{
    public string Value { get; }

    private TaxRegistrationNumber(string value)
    {
        Value = value;
    }

    public static TaxRegistrationNumber? FromNullable(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var normalized = value.Trim();

        if (normalized.Length < 5)
            throw new InvalidCompanyException("Tax registration number is too short.");

        if (normalized.Length > 32)
            throw new InvalidCompanyException("Tax registration number is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '/' && ch != ' ')
                throw new InvalidCompanyException("Tax registration number contains invalid characters.");
        }

        normalized = normalized.Replace(" ", string.Empty);

        return new TaxRegistrationNumber(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
