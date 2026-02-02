using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.TransferType;

namespace ERP.Domain.Setup.Inventory.Policies;

public static class TransferTypeCodeUniquenessPolicy
{
    public static void EnsureUnique(
        TransferTypeCode candidate,
        IReadOnlyCollection<TransferTypeCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(code => code.Equals(candidate)))
        {
            throw new InvalidTransferTypeException($"Transfer type code '{candidate.Value}' already exists.");
        }
    }
}
