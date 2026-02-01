using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals;

public interface IJournalRepository
{
    Task AddAsync(Journal journal, CancellationToken cancellationToken);
}
