namespace ERP.Application.Accounting.Ledgers.ListLedgers;

public sealed record LedgerListItemDto(
    string Id,
    DateOnly PeriodStart,
    DateOnly PeriodEnd,
    string Status
);
