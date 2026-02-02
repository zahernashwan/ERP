using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.CostCenters.CostCenter;
using ERP.Domain.Setup.System.Company;

namespace ERP.Domain.Setup.System.CostCenters.Policies;

public static class CostCenterCodeUniquenessPolicy
{
    public static void EnsureUnique(
        CompanyId companyId,
        CostCenterCode candidate,
        IReadOnlyCollection<CostCenterCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(c => c.Equals(candidate)))
        {
            throw new InvalidCostCenterException($"Cost center code '{candidate.Value}' already exists for this company.");
        }
    }
}
