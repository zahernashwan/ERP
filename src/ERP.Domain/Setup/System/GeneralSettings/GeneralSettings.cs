using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Currencies.Currency;

namespace ERP.Domain.Setup.System.GeneralSettings;

public sealed class GeneralSettings : Entity<GeneralSettingsId>
{
    private GeneralSettings(
        GeneralSettingsId id,
        CurrencyId baseCurrencyId,
        bool allowBackdatedPosting,
        bool allowFutureDatedPosting)
        : base(id)
    {
        BaseCurrencyId = baseCurrencyId;
        AllowBackdatedPosting = allowBackdatedPosting;
        AllowFutureDatedPosting = allowFutureDatedPosting;
    }

    public CurrencyId BaseCurrencyId { get; private set; }

    public bool AllowBackdatedPosting { get; private set; }

    public bool AllowFutureDatedPosting { get; private set; }

    public static GeneralSettings Create(
        GeneralSettingsId id,
        CurrencyId baseCurrencyId,
        bool allowBackdatedPosting,
        bool allowFutureDatedPosting)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(baseCurrencyId);

        return new GeneralSettings(id, baseCurrencyId, allowBackdatedPosting, allowFutureDatedPosting);
    }

    public void SetPostingPolicy(bool allowBackdatedPosting, bool allowFutureDatedPosting)
    {
        AllowBackdatedPosting = allowBackdatedPosting;
        AllowFutureDatedPosting = allowFutureDatedPosting;
    }

    public void ChangeBaseCurrency(CurrencyId newBaseCurrencyId, bool hasClosedFiscalPeriods)
    {
        ArgumentNullException.ThrowIfNull(newBaseCurrencyId);

        if (hasClosedFiscalPeriods)
            throw new InvalidGeneralSettingsException("Base currency cannot be changed when there are closed fiscal periods.");

        BaseCurrencyId = newBaseCurrencyId;
    }
}
