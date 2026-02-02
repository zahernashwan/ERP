namespace ERP.Domain.Setup.System.Branch;

public sealed class BranchId : ValueObject
{
    public Guid Value { get; }

    private BranchId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Branch id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static BranchId New() => new(Guid.NewGuid());

    public static BranchId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
