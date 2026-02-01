using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Journals.PostJournal;

public sealed record PostJournalCommand(JournalId JournalId);
