using ERP.Application.Accounting.Journals;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class InMemoryJournalRepository : IJournalRepository
{
    private static readonly Dictionary<JournalId, Journal> _journals = new();

    public Task AddAsync(Journal journal, CancellationToken cancellationToken)
    {
        _journals[journal.Id] = journal;
        return Task.CompletedTask;
    }

    public Task<Journal> GetByIdAsync(JournalId journalId, CancellationToken cancellationToken)
    {
        if (_journals.TryGetValue(journalId, out var journal))
        {
            return Task.FromResult(journal);
        }

        throw new InvalidOperationException($"Journal with id {journalId.Value} not found.");
    }
}
