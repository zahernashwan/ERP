using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.Inventory.PricingPolicy;
using Xunit;

namespace ERP.Domain.Tests.Setup.Inventory.PricingPolicy;

public sealed class PricingPolicyTests
{
    [Fact]
    public void Create_WhenMinimumMarginNegative_Throws()
    {
        Assert.Throws<InvalidPricingPolicyException>((Action)(() =>
            ERP.Domain.Setup.Inventory.PricingPolicy.PricingPolicy.Create(
                allowNegativeMargin: false,
                requirePriceList: true,
                allowManualPriceOverride: false,
                minimumMarginPercentage: -0.01m)));
    }

    [Fact]
    public void Create_WhenNoPricingMechanismEnabled_Throws()
    {
        Assert.Throws<InvalidPricingPolicyException>((Action)(() =>
            ERP.Domain.Setup.Inventory.PricingPolicy.PricingPolicy.Create(
                allowNegativeMargin: true,
                requirePriceList: false,
                allowManualPriceOverride: false,
                minimumMarginPercentage: 0m)));
    }

    [Fact]
    public void Create_WhenValid_WithPriceList_DoesNotThrow()
    {
        var policy = ERP.Domain.Setup.Inventory.PricingPolicy.PricingPolicy.Create(
            allowNegativeMargin: false,
            requirePriceList: true,
            allowManualPriceOverride: false,
            minimumMarginPercentage: 0m);

        Assert.True(policy.RequirePriceList);
    }

    [Fact]
    public void Create_WhenValid_WithManualOverride_DoesNotThrow()
    {
        var policy = ERP.Domain.Setup.Inventory.PricingPolicy.PricingPolicy.Create(
            allowNegativeMargin: true,
            requirePriceList: false,
            allowManualPriceOverride: true,
            minimumMarginPercentage: 10m);

        Assert.True(policy.AllowManualPriceOverride);
    }
}
