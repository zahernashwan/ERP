using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Company;
using ERP.Domain.Setup.System.CostCenters.CostCenter;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.CostCenters.CostCenter;

public sealed class CostCenterTests
{
    [Fact]
    public void CostCenterCode_From_WhenInvalidChars_Throws()
    {
        Assert.Throws<InvalidCostCenterException>(() => CostCenterCode.From("CC@1"));
    }

    [Fact]
    public void Create_WhenValid_SetsActive_AndBindsCompany()
    {
        var companyId = CompanyId.New();

        var cc = ERP.Domain.Setup.System.CostCenters.CostCenter.CostCenter.Create(
            CostCenterId.New(),
            companyId,
            CostCenterCode.From("CC-01"),
            CostCenterName.From("Main"));

        Assert.True(cc.IsActive);
        Assert.Equal(companyId, cc.CompanyId);
    }

    [Fact]
    public void ChangeCode_WhenUsed_Throws()
    {
        var cc = ERP.Domain.Setup.System.CostCenters.CostCenter.CostCenter.Create(
            CostCenterId.New(),
            CompanyId.New(),
            CostCenterCode.From("CC-01"),
            CostCenterName.From("Main"));

        Assert.Throws<InvalidCostCenterException>((Action)(() =>
            cc.ChangeCode(CostCenterCode.From("CC-02"), isUsed: true)));
    }

    [Fact]
    public void Deactivate_WhenUsed_Throws()
    {
        var cc = ERP.Domain.Setup.System.CostCenters.CostCenter.CostCenter.Create(
            CostCenterId.New(),
            CompanyId.New(),
            CostCenterCode.From("CC-01"),
            CostCenterName.From("Main"));

        Assert.Throws<InvalidCostCenterException>((Action)(() =>
            cc.Deactivate(isUsed: true)));
    }
}
