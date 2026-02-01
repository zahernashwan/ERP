namespace ERP.Application.Accounting.Journals.ListJournals;

public sealed record JournalListItemDto(
    string Id,
    string Number,
    DateOnly AccountingDate,
    string Status
);
