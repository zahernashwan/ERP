using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.FiscalPeriods.Policies;
using FiscalPeriodEntity = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod;
using ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod;
using Xunit;

namespace ERP.Domain.Tests.Setup.System.FiscalPeriods.Policies;

public sealed class FiscalPeriodOverlapPolicyTests
{
    [Fact]
    public void EnsureNoOverlap_WhenOverlaps_Throws()
    {
        var candidate = FiscalPeriodEntity.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 15),
            new DateOnly(2026, 2, 15));

        IReadOnlyCollection<FiscalPeriodEntity> existing =
        [
            FiscalPeriodEntity.Open(
                FiscalPeriodId.New(),
                new DateOnly(2026, 2, 1),
                new DateOnly(2026, 3, 1))
        ];

        Assert.Throws<InvalidFiscalPeriodException>((Action)(() =>
            FiscalPeriodOverlapPolicy.EnsureNoOverlap(candidate, existing)));
    }

    [Fact]
    public void EnsureNoOverlap_WhenTouchingBoundary_DoesNotThrow()
    {
        var candidate = FiscalPeriodEntity.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 1, 31));

        IReadOnlyCollection<FiscalPeriodEntity> existing =
        [
            FiscalPeriodEntity.Open(
                FiscalPeriodId.New(),
                new DateOnly(2026, 1, 31),
                new DateOnly(2026, 2, 28))
        ];

        FiscalPeriodOverlapPolicy.EnsureNoOverlap(candidate, existing);
    }

    [Fact]
    public void EnsureNoOverlap_WhenFullySeparate_DoesNotThrow()
    {
        var candidate = FiscalPeriodEntity.Open(
            FiscalPeriodId.New(),
            new DateOnly(2026, 1, 1),
            new DateOnly(2026, 1, 31));

        IReadOnlyCollection<FiscalPeriodEntity> existing =
        [
            FiscalPeriodEntity.Open(
                FiscalPeriodId.New(),
                new DateOnly(2026, 2, 1),
                new DateOnly(2026, 2, 28))
        ];

        FiscalPeriodOverlapPolicy.EnsureNoOverlap(candidate, existing);
    }
}
