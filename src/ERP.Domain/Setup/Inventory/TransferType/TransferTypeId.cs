namespace ERP.Domain.Setup.Inventory.TransferType;

public sealed class TransferTypeId : ValueObject
{
    public Guid Value { get; }

    private TransferTypeId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Transfer type id cannot be empty.", nameof(value));
        }

        Value = value;
    }

    public static TransferTypeId New() => new(Guid.NewGuid());

    public static TransferTypeId FromGuid(Guid value) => new(value);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString();
}
