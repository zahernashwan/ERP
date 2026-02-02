using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Branch;
using ERP.Domain.Setup.System.Company;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.Branch;

public sealed class BranchTests
{
    [Fact]
    public void BranchCode_From_WhenNullOrWhitespace_Throws()
    {
        Assert.Throws<InvalidBranchException>(() => BranchCode.From(" "));
    }

    [Fact]
    public void BranchCode_From_WhenHasInvalidChars_Throws()
    {
        Assert.Throws<InvalidBranchException>(() => BranchCode.From("AB@1"));
    }

    [Fact]
    public void BranchCode_From_WhenValid_NormalizesToUpper()
    {
        var code = BranchCode.From(" br-01 ");

        Assert.Equal("BR-01", code.Value);
    }

    [Fact]
    public void BranchName_From_WhenNullOrWhitespace_Throws()
    {
        Assert.Throws<InvalidBranchException>(() => BranchName.From(" "));
    }

    [Fact]
    public void Create_WhenValid_SetsActive_AndBindsCompany()
    {
        var companyId = CompanyId.New();

        var branch = ERP.Domain.Setup.System.Branch.Branch.Create(
            BranchId.New(),
            companyId,
            BranchCode.From("BR-01"),
            BranchName.From("Main Branch"));

        Assert.True(branch.IsActive);
        Assert.Equal(companyId, branch.CompanyId);
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var branch = ERP.Domain.Setup.System.Branch.Branch.Create(
            BranchId.New(),
            CompanyId.New(),
            BranchCode.From("BR-01"),
            BranchName.From("Main"));

        branch.Deactivate(canDeactivate: true);

        Assert.Throws<InvalidBranchException>((Action)(() => branch.Rename(BranchName.From("New"))));
    }

    [Fact]
    public void ChangeCode_WhenInactive_Throws()
    {
        var branch = ERP.Domain.Setup.System.Branch.Branch.Create(
            BranchId.New(),
            CompanyId.New(),
            BranchCode.From("BR-01"),
            BranchName.From("Main"));

        branch.Deactivate(canDeactivate: true);

        Assert.Throws<InvalidBranchException>((Action)(() => branch.ChangeCode(BranchCode.From("BR-02"))));
    }

    [Fact]
    public void Deactivate_WhenCannotDeactivate_Throws()
    {
        var branch = ERP.Domain.Setup.System.Branch.Branch.Create(
            BranchId.New(),
            CompanyId.New(),
            BranchCode.From("BR-01"),
            BranchName.From("Main"));

        Assert.Throws<InvalidBranchException>((Action)(() => branch.Deactivate(canDeactivate: false)));
    }
}
