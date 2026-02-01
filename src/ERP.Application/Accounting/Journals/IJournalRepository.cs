using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Journals;

public interface IJournalRepository
{
    Task AddAsync(Journal journal, CancellationToken cancellationToken);
    Task<Journal> GetByIdAsync(JournalId journalId, CancellationToken cancellationToken);
}
