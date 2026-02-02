using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.Currencies.Currency;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.Currencies.Currency;

public sealed class CurrencyTests
{
    [Fact]
    public void Create_WhenIsoCodeNull_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                null!,
                "US Dollar",
                2));
    }

    [Fact]
    public void Create_WhenIsoCodeWhitespace_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                "  ",
                "US Dollar",
                2));
    }

    [Fact]
    public void Create_WhenIsoCodeNotLength3_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                "US",
                "US Dollar",
                2));
    }

    [Fact]
    public void Create_WhenIsoCodeContainsNonLetters_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                "U$D",
                "US Dollar",
                2));
    }

    [Fact]
    public void Create_WhenNameMissing_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                "USD",
                " ",
                2));
    }

    [Fact]
    public void Create_WhenMinorUnitNegative_Throws()
    {
        Assert.Throws<InvalidCurrencyException>(() =>
            ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
                CurrencyId.New(),
                "USD",
                "US Dollar",
                -1));
    }

    [Fact]
    public void Create_WhenValid_NormalizesIsoCodeAndName()
    {
        var currency = ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
            CurrencyId.New(),
            " usd ",
            "  US Dollar  ",
            2);

        Assert.Equal("USD", currency.IsoCode);
        Assert.Equal("US Dollar", currency.Name);
        Assert.True(currency.IsActive);
    }

    [Fact]
    public void Rename_WhenInactive_Throws()
    {
        var currency = ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
            CurrencyId.New(),
            "USD",
            "US Dollar",
            2);

        currency.Deactivate();

        Assert.Throws<InvalidCurrencyException>(() => currency.Rename("Dollar"));
    }

    [Fact]
    public void Deactivate_WhenBaseCurrency_Throws()
    {
        var currency = ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
            CurrencyId.New(),
            "USD",
            "US Dollar",
            2,
            isBaseCurrency: true);

        Assert.Throws<InvalidCurrencyException>(() => currency.Deactivate());
    }

    [Fact]
    public void MarkAsBaseCurrency_WhenInactive_Throws()
    {
        var currency = ERP.Domain.Setup.System.Currencies.Currency.Currency.Create(
            CurrencyId.New(),
            "USD",
            "US Dollar",
            2);

        currency.Deactivate();

        Assert.Throws<InvalidCurrencyException>(() => currency.MarkAsBaseCurrency());
    }
}
