namespace ERP.Domain.Setup.System.Company;

public sealed class CompanyId : ValueObject
{
    public Guid Value { get; }

    private CompanyId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Company id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static CompanyId New() => new(Guid.NewGuid());

    public static CompanyId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
