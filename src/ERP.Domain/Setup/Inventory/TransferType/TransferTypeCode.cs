using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.TransferType;

public sealed class TransferTypeCode : ValueObject
{
    public string Value { get; }

    private TransferTypeCode(string value)
    {
        Value = value;
    }

    public static TransferTypeCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidTransferTypeException("Transfer type code is required.");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length < 2)
            throw new InvalidTransferTypeException("Transfer type code is too short.");

        if (normalized.Length > 10)
            throw new InvalidTransferTypeException("Transfer type code is too long.");

        for (var i = 0; i < normalized.Length; i++)
        {
            var ch = normalized[i];
            if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                throw new InvalidTransferTypeException("Transfer type code contains invalid characters.");
        }

        return new TransferTypeCode(normalized);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}
