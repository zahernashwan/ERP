using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Branch;
using ERP.Domain.Setup.System.Company;
using ERP.Domain.Setup.System.Company.Policies;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.Company.Policies;

public sealed class CompanyPolicyTests
{
    [Fact]
    public void EnsureCanAddBranch_WhenMaxBranchesInvalid_Throws()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-01");
        IReadOnlyCollection<BranchCode> existing = [];

        Assert.Throws<InvalidCompanyException>((Action)(() =>
            CompanyPolicy.EnsureCanAddBranch(companyId, candidate, existing, maxBranches: 0)));
    }

    [Fact]
    public void EnsureCanAddBranch_WhenMaxBranchesReached_Throws()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-03");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01"), BranchCode.From("BR-02")];

        Assert.Throws<InvalidCompanyException>((Action)(() =>
            CompanyPolicy.EnsureCanAddBranch(companyId, candidate, existing, maxBranches: 2)));
    }

    [Fact]
    public void EnsureCanAddBranch_WhenDuplicateCode_Throws()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-01");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01")];

        Assert.Throws<InvalidCompanyException>((Action)(() =>
            CompanyPolicy.EnsureCanAddBranch(companyId, candidate, existing, maxBranches: null)));
    }

    [Fact]
    public void EnsureCanAddBranch_WhenWithinLimitsAndUnique_DoesNotThrow()
    {
        var companyId = CompanyId.New();
        var candidate = BranchCode.From("BR-02");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01")];

        CompanyPolicy.EnsureCanAddBranch(companyId, candidate, existing, maxBranches: 100);
    }

    [Fact]
    public void EnsureCanChangeBranchCode_WhenNewEqualsCurrent_DoesNotThrow()
    {
        var companyId = CompanyId.New();
        var current = BranchCode.From("BR-01");
        var newCode = BranchCode.From("BR-01");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01")];

        CompanyPolicy.EnsureCanChangeBranchCode(companyId, current, newCode, existing);
    }

    [Fact]
    public void EnsureCanChangeBranchCode_WhenNewConflicts_Throws()
    {
        var companyId = CompanyId.New();
        var current = BranchCode.From("BR-01");
        var newCode = BranchCode.From("BR-02");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01"), BranchCode.From("BR-02")];

        Assert.Throws<InvalidCompanyException>((Action)(() =>
            CompanyPolicy.EnsureCanChangeBranchCode(companyId, current, newCode, existing)));
    }

    [Fact]
    public void EnsureCanChangeBranchCode_WhenNewIsUnique_DoesNotThrow()
    {
        var companyId = CompanyId.New();
        var current = BranchCode.From("BR-01");
        var newCode = BranchCode.From("BR-03");
        IReadOnlyCollection<BranchCode> existing = [BranchCode.From("BR-01"), BranchCode.From("BR-02")];

        CompanyPolicy.EnsureCanChangeBranchCode(companyId, current, newCode, existing);
    }
}
