using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.InventoryExpiryPolicy;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.InventoryExpiryPolicy;

public sealed class InventoryExpiryPolicyTests
{
    [Fact]
    public void Create_WhenMinimumDaysNegative_Throws()
    {
        Assert.Throws<InvalidInventoryExpiryPolicyException>((Action)(() =>
            ERP.Domain.Setup.System.InventoryExpiryPolicy.InventoryExpiryPolicy.Create(
                isExpiryRequired: true,
                minimumDaysBeforeExpiry: -1,
                allowSellAfterExpiry: false)));
    }

    [Fact]
    public void Create_WhenExpiryNotRequiredAndMinimumDaysNotZero_Throws()
    {
        Assert.Throws<InvalidInventoryExpiryPolicyException>((Action)(() =>
            ERP.Domain.Setup.System.InventoryExpiryPolicy.InventoryExpiryPolicy.Create(
                isExpiryRequired: false,
                minimumDaysBeforeExpiry: 1,
                allowSellAfterExpiry: false)));
    }

    [Fact]
    public void Create_WhenExpiryNotRequiredAndAllowSellAfterExpiryTrue_Throws()
    {
        Assert.Throws<InvalidInventoryExpiryPolicyException>((Action)(() =>
            ERP.Domain.Setup.System.InventoryExpiryPolicy.InventoryExpiryPolicy.Create(
                isExpiryRequired: false,
                minimumDaysBeforeExpiry: 0,
                allowSellAfterExpiry: true)));
    }

    [Fact]
    public void Create_WhenExpiryRequiredAndValid_CreatesPolicy()
    {
        var policy = ERP.Domain.Setup.System.InventoryExpiryPolicy.InventoryExpiryPolicy.Create(
            isExpiryRequired: true,
            minimumDaysBeforeExpiry: 30,
            allowSellAfterExpiry: false);

        Assert.True(policy.IsExpiryRequired);
    }
}
