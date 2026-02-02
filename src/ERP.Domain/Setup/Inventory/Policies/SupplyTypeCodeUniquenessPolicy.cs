using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.SupplyType;

namespace ERP.Domain.Setup.Inventory.Policies;

public static class SupplyTypeCodeUniquenessPolicy
{
    public static void EnsureUnique(
        SupplyTypeCode candidate,
        IReadOnlyCollection<SupplyTypeCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(code => code.Equals(candidate)))
        {
            throw new InvalidSupplyTypeException($"Supply type code '{candidate.Value}' already exists.");
        }
    }
}
