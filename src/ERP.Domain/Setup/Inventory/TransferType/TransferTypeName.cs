using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.TransferType;

public sealed class TransferTypeName : ValueObject
{
    public string Value { get; }

    private TransferTypeName(string value)
    {
        Value = value;
    }

    public static TransferTypeName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidTransferTypeException("Transfer type name is required.");

        var normalized = value.Trim();

        if (normalized.Length < 2)
            throw new InvalidTransferTypeException("Transfer type name is too short.");

        if (normalized.Length > 120)
            throw new InvalidTransferTypeException("Transfer type name is too long.");

        return new TransferTypeName(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
