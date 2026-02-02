using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.InventoryExpiryPolicy;

public sealed class InventoryExpiryPolicy : ValueObject
{
    public bool IsExpiryRequired { get; }

    /// <summary>
    /// Minimum number of days before expiry date that should be considered acceptable for selling/issuing.
    /// Example: 0 means "today is acceptable" (subject to AllowSellAfterExpiry).
    /// </summary>
    public int MinimumDaysBeforeExpiry { get; }

    public bool AllowSellAfterExpiry { get; }

    private InventoryExpiryPolicy(bool isExpiryRequired, int minimumDaysBeforeExpiry, bool allowSellAfterExpiry)
    {
        IsExpiryRequired = isExpiryRequired;
        MinimumDaysBeforeExpiry = minimumDaysBeforeExpiry;
        AllowSellAfterExpiry = allowSellAfterExpiry;
    }

    public static InventoryExpiryPolicy Create(bool isExpiryRequired, int minimumDaysBeforeExpiry, bool allowSellAfterExpiry)
    {
        if (minimumDaysBeforeExpiry < 0)
            throw new InvalidInventoryExpiryPolicyException("MinimumDaysBeforeExpiry must be >= 0.");

        if (!isExpiryRequired)
        {
            if (minimumDaysBeforeExpiry != 0)
                throw new InvalidInventoryExpiryPolicyException("MinimumDaysBeforeExpiry must be 0 when expiry is not required.");

            if (allowSellAfterExpiry)
                throw new InvalidInventoryExpiryPolicyException("AllowSellAfterExpiry cannot be enabled when expiry is not required.");
        }

        return new InventoryExpiryPolicy(isExpiryRequired, minimumDaysBeforeExpiry, allowSellAfterExpiry);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IsExpiryRequired;
        yield return MinimumDaysBeforeExpiry;
        yield return AllowSellAfterExpiry;
    }
}
