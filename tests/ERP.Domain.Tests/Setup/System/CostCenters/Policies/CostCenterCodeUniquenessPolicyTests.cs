using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Company;
using ERP.Domain.Setup.System.CostCenters.CostCenter;
using ERP.Domain.Setup.System.CostCenters.Policies;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.CostCenters.Policies;

public sealed class CostCenterCodeUniquenessPolicyTests
{
    [Fact]
    public void EnsureUnique_WhenDuplicate_Throws()
    {
        var companyId = CompanyId.New();
        var candidate = CostCenterCode.From("CC-01");
        IReadOnlyCollection<CostCenterCode> existing = [CostCenterCode.From("CC-01")];

        Assert.Throws<InvalidCostCenterException>((Action)(() =>
            CostCenterCodeUniquenessPolicy.EnsureUnique(companyId, candidate, existing)));
    }

    [Fact]
    public void EnsureUnique_WhenUnique_DoesNotThrow()
    {
        var companyId = CompanyId.New();
        var candidate = CostCenterCode.From("CC-02");
        IReadOnlyCollection<CostCenterCode> existing = [CostCenterCode.From("CC-01")];

        CostCenterCodeUniquenessPolicy.EnsureUnique(companyId, candidate, existing);
    }
}
