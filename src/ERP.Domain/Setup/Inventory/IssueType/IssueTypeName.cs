using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.IssueType;

public sealed class IssueTypeName : ValueObject
{
    public string Value { get; }

    private IssueTypeName(string value)
    {
        Value = value;
    }

    public static IssueTypeName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidIssueTypeException("Issue type name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidIssueTypeException("Issue type name is too short.");

        if (normalized.Length > 120)
            throw new InvalidIssueTypeException("Issue type name is too long.");

        return new IssueTypeName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
