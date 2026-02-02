using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.IssueType;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.IssueType;

public sealed class IssueTypeTests
{
    [Fact]
    public void IssueTypeCode_From_WhenInvalidChars_Throws()
    {
        Assert.Throws<InvalidIssueTypeException>(() => IssueTypeCode.From("AB@1"));
    }

    [Fact]
    public void IssueTypeCode_From_WhenValid_NormalizesToUpper()
    {
        var code = IssueTypeCode.From(" iss-01 ");

        Assert.Equal("ISS-01", code.Value);
    }

    [Fact]
    public void Deactivate_WhenUsed_Throws()
    {
        var it = ERP.Domain.Setup.Inventory.IssueType.IssueType.Create(
            IssueTypeId.New(),
            IssueTypeCode.From("ISS"),
            IssueTypeName.From("Issue"));

        Assert.Throws<InvalidIssueTypeException>((Action)(() => it.Deactivate(isUsed: true)));
    }

    [Fact]
    public void ChangeCode_WhenUsed_Throws()
    {
        var it = ERP.Domain.Setup.Inventory.IssueType.IssueType.Create(
            IssueTypeId.New(),
            IssueTypeCode.From("ISS"),
            IssueTypeName.From("Issue"));

        Assert.Throws<InvalidIssueTypeException>((Action)(() =>
            it.ChangeCode(IssueTypeCode.From("ISS2"), isUsed: true)));
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var it = ERP.Domain.Setup.Inventory.IssueType.IssueType.Create(
            IssueTypeId.New(),
            IssueTypeCode.From("ISS"),
            IssueTypeName.From("Issue"));

        it.Deactivate(isUsed: false);

        Assert.Throws<InvalidIssueTypeException>((Action)(() =>
            it.Rename(IssueTypeName.From("New"))));
    }
}
