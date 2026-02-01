using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Journals.AddJournalLine;

public sealed record AddJournalLineCommand(
    JournalId JournalId,
    AccountId AccountId,
    Money Amount,
    bool IsDebit,
    string? Description = null,
    ProjectId? ProjectId = null
);
