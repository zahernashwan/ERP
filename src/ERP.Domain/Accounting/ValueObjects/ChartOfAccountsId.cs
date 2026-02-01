namespace ERP.Domain.Accounting.ValueObjects;

public sealed class ChartOfAccountsId : ValueObject
{
    public Guid Value { get; }

    private ChartOfAccountsId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Chart of accounts id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static ChartOfAccountsId New() => new(Guid.NewGuid());

    public static ChartOfAccountsId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
