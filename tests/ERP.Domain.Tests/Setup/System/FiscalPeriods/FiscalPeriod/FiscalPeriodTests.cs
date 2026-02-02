using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.FiscalPeriods.FiscalPeriod;

public sealed class FiscalPeriodTests
{
    [Fact]
    public void Open_WhenStartDateDefault_Throws()
    {
        Assert.Throws<InvalidFiscalPeriodException>(() =>
            ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
                FiscalPeriodId.New(),
                default,
                new DateOnly(2026, 12, 31)));
    }

    [Fact]
    public void Open_WhenEndDateDefault_Throws()
    {
        Assert.Throws<InvalidFiscalPeriodException>(() =>
            ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
                FiscalPeriodId.New(),
                new DateOnly(2026, 1, 1),
                default));
    }

    [Fact]
    public void Open_WhenEndBeforeStart_Throws()
    {
        Assert.Throws<InvalidFiscalPeriodException>(() =>
            ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
                FiscalPeriodId.New(),
                new DateOnly(2026, 2, 1),
                new DateOnly(2026, 1, 1)));
    }

    [Fact]
    public void Close_WhenCalled_ClosesPeriod()
    {
        var period = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 12, 31));

        period.Close();

        Assert.True(period.IsClosed);
    }

    [Fact]
    public void Close_WhenAlreadyClosed_Throws()
    {
        var period = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 12, 31));

        period.Close();

        Assert.Throws<InvalidFiscalPeriodException>(() => period.Close());
    }

    [Fact]
    public void Contains_WhenInRange_ReturnsTrue()
    {
        var period = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 12, 31));

        var result = period.Contains(new DateOnly(2026, 6, 1));

        Assert.True(result);
    }

    [Fact]
    public void Contains_WhenDateDefault_Throws()
    {
        var period = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 12, 31));

        Assert.Throws<InvalidFiscalPeriodException>(() => period.Contains(default));
    }
}
