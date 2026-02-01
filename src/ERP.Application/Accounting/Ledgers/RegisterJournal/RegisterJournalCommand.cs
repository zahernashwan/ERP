using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Ledgers.RegisterJournal;

public sealed record RegisterJournalCommand(
    LedgerId LedgerId,
    JournalId JournalId
);
