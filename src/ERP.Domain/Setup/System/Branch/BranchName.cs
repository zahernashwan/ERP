using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.Branch;

public sealed class BranchName : ValueObject
{
    public string Value { get; }

    private BranchName(string value)
    {
        Value = value;
    }

    public static BranchName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidBranchException("Branch name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidBranchException("Branch name is too short.");

        if (normalized.Length > 120)
            throw new InvalidBranchException("Branch name is too long.");

        return new BranchName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
