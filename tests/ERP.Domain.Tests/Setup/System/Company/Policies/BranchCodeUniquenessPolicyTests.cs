using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Branch;
using ERP.Domain.Setup.System.Company;
using ERP.Domain.Setup.System.Company.Policies;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.Company.Policies;

public sealed class BranchCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenExistingCodesContainsCandidate_Throws()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-01");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01")];

        Assert.Throws<InvalidCompanyException>((Action)(() =>
            BranchCodeUniquenessPolicy.EnsureUnique(companyId, candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenCandidateIsUnique_DoesNotThrow()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-02");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01")];

        BranchCodeUniquenessPolicy.EnsureUnique(companyId, candidate, existing);
    }
}
