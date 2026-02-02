using ERP.Domain.Setup.Exceptions;

namespace ERP.Domain.Setup.System.FiscalPeriods.FiscalPeriod;

public sealed class FiscalPeriod : Entity<FiscalPeriodId>
{
    private FiscalPeriod(
        FiscalPeriodId id,
        DateOnly startDate,
        DateOnly endDate,
        bool isClosed)
        : base(id)
    {
        StartDate = startDate;
        EndDate = endDate;
        IsClosed = isClosed;
    }

    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public bool IsClosed { get; private set; }
    public DateTimeOffset? ClosedAt { get; private set; }

    public static FiscalPeriod Open(FiscalPeriodId id, DateOnly startDate, DateOnly endDate)
    {
        ArgumentNullException.ThrowIfNull(id);

        if (startDate == default)
            throw new InvalidFiscalPeriodException("Start date is required.");

        if (endDate == default)
            throw new InvalidFiscalPeriodException("End date is required.");

        if (endDate < startDate)
            throw new InvalidFiscalPeriodException("End date cannot be before start date.");

        return new FiscalPeriod(id, startDate, endDate, isClosed: false);
    }

    public void Close()
    {
        EnsureOpen();
        IsClosed = true;
        ClosedAt = DateTimeOffset.UtcNow;
    }

    public bool Contains(DateOnly date)
    {
        if (date == default)
            throw new InvalidFiscalPeriodException("Date is required.");

        return date >= StartDate && date <= EndDate;
    }

    private void EnsureOpen()
    {
        if (IsClosed)
            throw new InvalidFiscalPeriodException("Fiscal period is closed.");
    }
}
