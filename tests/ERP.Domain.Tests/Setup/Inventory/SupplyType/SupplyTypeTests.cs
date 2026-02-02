using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.SupplyType;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.SupplyType;

public sealed class SupplyTypeTests
{
    [Fact]
    public void SupplyTypeCode_From_WhenInvalidChars_Throws()
    {
        Assert.Throws<InvalidSupplyTypeException>(() => SupplyTypeCode.From("AB@1"));
    }

    [Fact]
    public void SupplyTypeCode_From_WhenValid_NormalizesToUpper()
    {
        var code = SupplyTypeCode.From(" in-01 ");

        Assert.Equal("IN-01", code.Value);
    }

    [Fact]
    public void Deactivate_WhenUsed_Throws()
    {
        var st = ERP.Domain.Setup.Inventory.SupplyType.SupplyType.Create(
            SupplyTypeId.New(),
            SupplyTypeCode.From("IN"),
            SupplyTypeName.From("Inbound"));

        Assert.Throws<InvalidSupplyTypeException>((Action)(() => st.Deactivate(isUsed: true)));
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var st = ERP.Domain.Setup.Inventory.SupplyType.SupplyType.Create(
            SupplyTypeId.New(),
            SupplyTypeCode.From("IN"),
            SupplyTypeName.From("Inbound"));

        st.Deactivate(isUsed: false);

        Assert.Throws<InvalidSupplyTypeException>((Action)(() =>
            st.Rename(SupplyTypeName.From("New"))));
    }
}
