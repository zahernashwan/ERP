using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Branch;

namespace ERP.Domain.Setup.System.Company.Policies;

public static class CompanyPolicy
{
    public static void EnsureCanAddBranch(
        CompanyId companyId,
        BranchCode candidateCode,
        IReadOnlyCollection<BranchCode> existingCodes,
        int? maxBranches)
    {
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(candidateCode);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (maxBranches is < 1)
            throw new InvalidCompanyException("Max branches must be null or >= 1.");

        if (maxBranches is not null && existingCodes.Count >= maxBranches.Value)
            throw new InvalidCompanyException("Company has reached the maximum allowed number of branches.");

        BranchCodeUniquenessPolicy.EnsureUnique(companyId, candidateCode, existingCodes);
    }

    public static void EnsureCanChangeBranchCode(
        CompanyId companyId,
        BranchCode currentCode,
        BranchCode newCode,
        IReadOnlyCollection<BranchCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(companyId);
        ArgumentNullException.ThrowIfNull(currentCode);
        ArgumentNullException.ThrowIfNull(newCode);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (currentCode.Equals(newCode))
            return;

        // The caller passes existing codes (typically including the current code).
        // To validate uniqueness for the new code, ignore the current code.
        var otherCodes = existingCodes.Where(code => !code.Equals(currentCode)).ToArray();

        BranchCodeUniquenessPolicy.EnsureUnique(companyId, newCode, otherCodes);
    }
}
