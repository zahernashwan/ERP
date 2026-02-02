using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Branch;

public sealed class BranchCode : ValueObject
{
    public string Value { get; }

    private BranchCode(string value)
    {
        Value = value;
    }

    public static BranchCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidBranchException("Branch code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 2)
            throw new InvalidBranchException("Branch code is too short.");

        if (normalized.Length > 12)
            throw new InvalidBranchException("Branch code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                throw new InvalidBranchException("Branch code contains invalid characters.");
        }

        return new BranchCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
