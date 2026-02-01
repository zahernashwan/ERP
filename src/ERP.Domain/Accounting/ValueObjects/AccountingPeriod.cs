namespace ERP.Domain.Accounting.ValueObjects;

public sealed class AccountingPeriod : ValueObject
{
    public DateOnly Start { get; }
    public DateOnly End { get; }

    private AccountingPeriod(DateOnly start, DateOnly end)
    {
        Start = start;
        End = end;
    }

    public static AccountingPeriod Create(DateOnly start, DateOnly end)
    {
        if (start == default)
        {
            throw new ArgumentOutOfRangeException(nameof(start), "Start date is required.");
        }

        if (end == default)
        {
            throw new ArgumentOutOfRangeException(nameof(end), "End date is required.");
        }

        if (end < start)
        {
            throw new ArgumentOutOfRangeException(nameof(end), "End date cannot be before start date.");
        }

        return new AccountingPeriod(start, end);
    }

    public bool Contains(DateOnly date)
    {
        if (date == default)
        {
            throw new ArgumentOutOfRangeException(nameof(date), "Date is required.");
        }

        return date >= Start && date <= End;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}
