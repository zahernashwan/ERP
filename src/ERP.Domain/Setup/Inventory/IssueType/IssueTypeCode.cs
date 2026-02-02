using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.IssueType;

public sealed class IssueTypeCode : ValueObject
{
    public string Value { get; }

    private IssueTypeCode(string value)
    {
        Value = value;
    }

    public static IssueTypeCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidIssueTypeException("Issue type code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 2)
            throw new InvalidIssueTypeException("Issue type code is too short.");

        if (normalized.Length > 10)
            throw new InvalidIssueTypeException("Issue type code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                throw new InvalidIssueTypeException("Issue type code contains invalid characters.");
        }

        return new IssueTypeCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
