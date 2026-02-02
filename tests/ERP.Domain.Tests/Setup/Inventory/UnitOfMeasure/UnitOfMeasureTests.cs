using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.UnitOfMeasure;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.UnitOfMeasure;

public sealed class UnitOfMeasureTests
{
    [Fact]
    public void UnitOfMeasureCode_From_WhenHasNonAlphanumeric_Throws()
    {
        Assert.Throws<InvalidUnitOfMeasureException>(() => UnitOfMeasureCode.From("KG-1"));
    }

    [Fact]
    public void UnitOfMeasureCode_From_WhenValid_NormalizesToUpper()
    {
        var code = UnitOfMeasureCode.From(" kg ");

        Assert.Equal("KG", code.Value);
    }

    [Fact]
    public void Deactivate_WhenUsed_Throws()
    {
        var uom = ERP.Domain.Setup.Inventory.UnitOfMeasure.UnitOfMeasure.Create(
            UnitOfMeasureId.New(),
            UnitOfMeasureCode.From("KG"),
            UnitOfMeasureName.From("Kilogram"));

        Assert.Throws<InvalidUnitOfMeasureException>((Action)(() => uom.Deactivate(isUsed: true)));
    }

    [Fact]
    public void ChangeCode_WhenUsed_Throws()
    {
        var uom = ERP.Domain.Setup.Inventory.UnitOfMeasure.UnitOfMeasure.Create(
            UnitOfMeasureId.New(),
            UnitOfMeasureCode.From("KG"),
            UnitOfMeasureName.From("Kilogram"));

        Assert.Throws<InvalidUnitOfMeasureException>((Action)(() =>
            uom.ChangeCode(UnitOfMeasureCode.From("G"), isUsed: true)));
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var uom = ERP.Domain.Setup.Inventory.UnitOfMeasure.UnitOfMeasure.Create(
            UnitOfMeasureId.New(),
            UnitOfMeasureCode.From("KG"),
            UnitOfMeasureName.From("Kilogram"));

        uom.Deactivate(isUsed: false);

        Assert.Throws<InvalidUnitOfMeasureException>((Action)(() =>
            uom.Rename(UnitOfMeasureName.From("New Name"))));
    }
}
