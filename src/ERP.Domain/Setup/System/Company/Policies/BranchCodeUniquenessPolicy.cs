using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Branch;

namespace ERP.Domain.Setup.System.Company.Policies;

public static class BranchCodeUniquenessPolicy
{
    public static void EnsureUnique(
        CompanyId companyId,
        BranchCode candidate,
        IReadOnlyCollection<BranchCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(code => code.Equals(candidate)))
        {
            throw new InvalidCompanyException($"Branch code '{candidate.Value}' already exists for this company.");
        }
    }
}
