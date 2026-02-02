using ERP.Domain.Setup.Exceptions;
using FiscalPeriodEntity = ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod.FiscalPeriod;

namespace ERP.Domain.Setup.System.FiscalPeriods.Policies;

public static class FiscalPeriodOverlapPolicy
{
    public static void EnsureNoOverlap(
        FiscalPeriodEntity candidate,
        IReadOnlyCollection<FiscalPeriodEntity> existingPeriods)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingPeriods);

        foreach (var existing in existingPeriods)
        {
            ArgumentNullException.ThrowIfNull(existing);

            if (Overlaps(candidate, existing))
            {
                throw new InvalidFiscalPeriodException(
                    $"Fiscal period [{candidate.StartDate:yyyy-MM-dd}..{candidate.EndDate:yyyy-MM-dd}] overlaps with existing period [{existing.StartDate:yyyy-MM-dd}..{existing.EndDate:yyyy-MM-dd}].");
            }
        }
    }

    private static bool Overlaps(FiscalPeriodEntity a, FiscalPeriodEntity b)
    {
        // Touching boundaries is allowed: [aStart..aEnd] and [bStart..bEnd] do NOT overlap if aEnd == bStart or bEnd == aStart.
        // Overlap exists when ranges intersect with a positive-length intersection.
        return a.StartDate < b.EndDate && a.EndDate > b.StartDate;
    }
}
