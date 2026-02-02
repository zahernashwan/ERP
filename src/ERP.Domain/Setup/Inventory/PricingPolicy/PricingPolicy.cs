using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.Inventory.PricingPolicy;

public sealed class PricingPolicy : ValueObject
{
    public bool AllowNegativeMargin { get; }
    public bool RequirePriceList { get; }
    public bool AllowManualPriceOverride { get; }
    public decimal MinimumMarginPercentage { get; }

    private PricingPolicy(
        bool allowNegativeMargin,
        bool requirePriceList,
        bool allowManualPriceOverride,
        decimal minimumMarginPercentage)
    {
        AllowNegativeMargin = allowNegativeMargin;
        RequirePriceList = requirePriceList;
        AllowManualPriceOverride = allowManualPriceOverride;
        MinimumMarginPercentage = minimumMarginPercentage;
    }

    public static PricingPolicy Create(
        bool allowNegativeMargin,
        bool requirePriceList,
        bool allowManualPriceOverride,
        decimal minimumMarginPercentage)
    {
        if (minimumMarginPercentage < 0)
            throw new InvalidPricingPolicyException("MinimumMarginPercentage must be >= 0.");

        if (!requirePriceList && !allowManualPriceOverride)
            throw new InvalidPricingPolicyException("At least one pricing mechanism must be enabled (price list or manual override).");

        return new PricingPolicy(allowNegativeMargin, requirePriceList, allowManualPriceOverride, minimumMarginPercentage);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return AllowNegativeMargin;
        yield return RequirePriceList;
        yield return AllowManualPriceOverride;
        yield return MinimumMarginPercentage;
    }
}
