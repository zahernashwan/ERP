using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Journals.StartJournal;

public sealed record StartJournalCommand(
    JournalId Id,
    JournalNumber Number,
    DateOnly AccountingDate,
    string? Reference
);
