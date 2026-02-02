using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.UnitOfMeasure;

namespace ERP.Domain.Setup.Inventory.Policies;

public static class UnitOfMeasureCodeUniquenessPolicy
{
    public static void EnsureUnique(
        UnitOfMeasureCode candidate,
        IReadOnlyCollection<UnitOfMeasureCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(code => code.Equals(candidate)))
        {
            throw new InvalidUnitOfMeasureException($"Unit of measure code '{candidate.Value}' already exists.");
        }
    }
}
