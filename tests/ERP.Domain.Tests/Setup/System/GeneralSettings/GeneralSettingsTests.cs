using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Currencies.Currency;
using ERP.Domain.Setup.System.GeneralSettings;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.GeneralSettings;

public sealed class GeneralSettingsTests
{
    [Fact]
    public void Create_WhenValid_SetsBaseCurrencyId()
    {
        var baseCurrencyId = CurrencyId.New();

        var settings = ERP.Domain.Setup.System.GeneralSettings.GeneralSettings.Create(
            GeneralSettingsId.New(),
            baseCurrencyId,
            allowBackdatedPosting: false,
            allowFutureDatedPosting: false);

        Assert.Equal(baseCurrencyId, settings.BaseCurrencyId);
    }

    [Fact]
    public void ChangeBaseCurrency_WhenHasClosedFiscalPeriods_Throws()
    {
        var settings = ERP.Domain.Setup.System.GeneralSettings.GeneralSettings.Create(
            GeneralSettingsId.New(),
            CurrencyId.New(),
            allowBackdatedPosting: false,
            allowFutureDatedPosting: false);

        Assert.Throws<InvalidGeneralSettingsException>((Action)(() =>
            settings.ChangeBaseCurrency(CurrencyId.New(), hasClosedFiscalPeriods: true)));
    }

    [Fact]
    public void ChangeBaseCurrency_WhenNoClosedFiscalPeriods_ChangesId()
    {
        var settings = ERP.Domain.Setup.System.GeneralSettings.GeneralSettings.Create(
            GeneralSettingsId.New(),
            CurrencyId.New(),
            allowBackdatedPosting: false,
            allowFutureDatedPosting: false);

        var newBaseCurrencyId = CurrencyId.New();

        settings.ChangeBaseCurrency(newBaseCurrencyId, hasClosedFiscalPeriods: false);

        Assert.Equal(newBaseCurrencyId, settings.BaseCurrencyId);
    }
}
