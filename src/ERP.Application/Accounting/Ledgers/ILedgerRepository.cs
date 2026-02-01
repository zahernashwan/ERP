using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Ledgers;

public interface ILedgerRepository
{
    Task AddAsync(Ledger ledger, CancellationToken cancellationToken);
    Task<Ledger> GetByIdAsync(LedgerId ledgerId, CancellationToken cancellationToken);
}
