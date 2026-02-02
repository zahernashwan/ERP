namespace ERP.Domain.Setup.Inventory.IssueType;

public sealed class IssueTypeId : ValueObject
{
    public Guid Value { get; }

    private IssueTypeId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Issue type id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static IssueTypeId New() => new(Guid.NewGuid());

    public static IssueTypeId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
