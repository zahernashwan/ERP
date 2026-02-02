using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.IssueType;

namespace ERP.Domain.Setup.Inventory.Policies;

public static class IssueTypeCodeUniquenessPolicy
{
    public static void EnsureUnique(
        IssueTypeCode candidate,
        IReadOnlyCollection<IssueTypeCode> existingCodes)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingCodes);

        if (existingCodes.Any(code => code.Equals(candidate)))
        {
            throw new InvalidIssueTypeException($"Issue type code '{candidate.Value}' already exists.");
        }
    }
}
