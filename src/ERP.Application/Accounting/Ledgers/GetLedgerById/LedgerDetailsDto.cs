namespace ERP.Application.Accounting.Ledgers.GetLedgerById;

public sealed record LedgerDetailsDto(
    string Id,
    DateOnly PeriodStart,
    DateOnly PeriodEnd,
    string Status,
    DateTimeOffset? ClosedAt,
    IReadOnlyList<string> JournalIds
);
