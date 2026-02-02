using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Company;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.Company;

public sealed class CompanyTests
{
    [Fact]
    public void CompanyName_From_WhenNullOrWhitespace_Throws()
    {
        Assert.Throws<InvalidCompanyException>(() => CompanyName.From(" "));
    }

    [Fact]
    public void CompanyName_From_WhenTooShort_Throws()
    {
        Assert.Throws<InvalidCompanyException>(() => CompanyName.From("A"));
    }

    [Fact]
    public void CompanyName_From_WhenValid_Trims()
    {
        var name = CompanyName.From("  ACME  ");

        Assert.Equal("ACME", name.Value);
    }

    [Fact]
    public void TaxRegistrationNumber_FromNullable_WhenNull_ReturnsNull()
    {
        var trn = TaxRegistrationNumber.FromNullable(null);

        Assert.Null(trn);
    }

    [Fact]
    public void TaxRegistrationNumber_FromNullable_WhenWhitespace_ReturnsNull()
    {
        var trn = TaxRegistrationNumber.FromNullable("   ");

        Assert.Null(trn);
    }

    [Fact]
    public void TaxRegistrationNumber_FromNullable_WhenTooShort_Throws()
    {
        Assert.Throws<InvalidCompanyException>(() => TaxRegistrationNumber.FromNullable("1234"));
    }

    [Fact]
    public void TaxRegistrationNumber_FromNullable_WhenHasInvalidChars_Throws()
    {
        Assert.Throws<InvalidCompanyException>(() => TaxRegistrationNumber.FromNullable("ABC@123"));
    }

    [Fact]
    public void TaxRegistrationNumber_FromNullable_WhenValid_RemovesSpaces()
    {
        var trn = TaxRegistrationNumber.FromNullable("  ABC 123  ");

        Assert.NotNull(trn);
        Assert.Equal("ABC123", trn!.Value);
    }

    [Fact]
    public void Create_WhenValid_SetsActive()
    {
        var company = ERP.Domain.Setup.System.Company.Company.Create(CompanyId.New(), CompanyName.From("ACME"));

        Assert.True(company.IsActive);
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var company = ERP.Domain.Setup.System.Company.Company.Create(CompanyId.New(), CompanyName.From("ACME"));
        company.Deactivate("Closed");

        Assert.Throws<InvalidCompanyException>((Action)(() => company.Rename(CompanyName.From("New"))));
    }

    [Fact]
    public void Deactivate_WhenReasonMissing_Throws()
    {
        var company = ERP.Domain.Setup.System.Company.Company.Create(CompanyId.New(), CompanyName.From("ACME"));

        Assert.Throws<InvalidCompanyException>((Action)(() => company.Deactivate("   ")));
    }

    [Fact]
    public void Deactivate_WhenAlreadyInactive_Throws()
    {
        var company = ERP.Domain.Setup.System.Company.Company.Create(CompanyId.New(), CompanyName.From("ACME"));
        company.Deactivate("Closed");

        Assert.Throws<InvalidCompanyException>((Action)(() => company.Deactivate("Again")));
    }

    [Fact]
    public void Activate_WhenInactive_SetsActive()
    {
        var company = ERP.Domain.Setup.System.Company.Company.Create(CompanyId.New(), CompanyName.From("ACME"));
        company.Deactivate("Closed");

        company.Activate();

        Assert.True(company.IsActive);
    }
}
