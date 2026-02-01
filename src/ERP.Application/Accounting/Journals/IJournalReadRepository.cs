using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals;

public interface IJournalReadRepository
{
    Task<IReadOnlyList<Journal>> GetAllAsync(CancellationToken cancellationToken);
}
