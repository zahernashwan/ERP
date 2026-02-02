using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Journals.GetJournalById;

public sealed record GetJournalByIdQuery(JournalId JournalId)
{
    public static GetJournalByIdQuery FromString(string journalId)
    {
        if (string.IsNullOrWhiteSpace(journalId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(journalId));

        if (!Guid.TryParse(journalId, out var id))
            throw new FormatException($"Invalid Journal Id: '{journalId}'.");

        return new GetJournalByIdQuery(JournalId.FromGuid(id));
    }
}
