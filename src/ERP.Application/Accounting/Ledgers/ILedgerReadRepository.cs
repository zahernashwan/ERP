using ERP.Domain.Accounting.Aggregates.Ledgers;

namespace ERP.Application.Accounting.Ledgers;

public interface ILedgerReadRepository
{
    Task<IReadOnlyList<Ledger>> GetAllAsync(CancellationToken cancellationToken);
}
