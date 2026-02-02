using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.TransferType;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.TransferType;

public sealed class TransferTypeTests
{
    [Fact]
    public void TransferTypeCode_From_WhenInvalidChars_Throws()
    {
        Assert.Throws<InvalidTransferTypeException>(() => TransferTypeCode.From("AB@1"));
    }

    [Fact]
    public void TransferTypeCode_From_WhenValid_NormalizesToUpper()
    {
        var code = TransferTypeCode.From(" tr-01 ");

        Assert.Equal("TR-01", code.Value);
    }

    [Fact]
    public void Deactivate_WhenUsed_Throws()
    {
        var tt = ERP.Domain.Setup.Inventory.TransferType.TransferType.Create(
            TransferTypeId.New(),
            TransferTypeCode.From("TR"),
            TransferTypeName.From("Transfer"));

        Assert.Throws<InvalidTransferTypeException>((Action)(() => tt.Deactivate(isUsed: true)));
    }

    [Fact]
    public void ChangeCode_WhenUsed_Throws()
    {
        var tt = ERP.Domain.Setup.Inventory.TransferType.TransferType.Create(
            TransferTypeId.New(),
            TransferTypeCode.From("TR"),
            TransferTypeName.From("Transfer"));

        Assert.Throws<InvalidTransferTypeException>((Action)(() =>
            tt.ChangeCode(TransferTypeCode.From("TR2"), isUsed: true)));
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var tt = ERP.Domain.Setup.Inventory.TransferType.TransferType.Create(
            TransferTypeId.New(),
            TransferTypeCode.From("TR"),
            TransferTypeName.From("Transfer"));

        tt.Deactivate(isUsed: false);

        Assert.Throws<InvalidTransferTypeException>((Action)(() =>
            tt.Rename(TransferTypeName.From("New"))));
    }
}
