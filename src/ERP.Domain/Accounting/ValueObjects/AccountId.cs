namespace ERP.Domain.Accounting.ValueObjects;

public sealed class AccountId : ValueObject
{
    public Guid Value { get; }

    private AccountId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Account id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static AccountId New() => new(Guid.NewGuid());

    public static AccountId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
