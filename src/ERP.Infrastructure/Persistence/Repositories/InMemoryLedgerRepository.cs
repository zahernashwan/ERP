using ERP.Application.Accounting.Ledgers;
using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class InMemoryLedgerRepository : ILedgerRepository, ILedgerReadRepository
{
    private static readonly Dictionary<LedgerId, Ledger> _ledgers = [];

    public Task AddAsync(Ledger ledger, CancellationToken cancellationToken)
    {
        _ledgers[ledger.Id] = ledger;
        return Task.CompletedTask;
    }

    public Task<Ledger> GetByIdAsync(LedgerId ledgerId, CancellationToken cancellationToken)
    {
        if (_ledgers.TryGetValue(ledgerId, out var ledger))
        {
            return Task.FromResult(ledger);
        }

        throw new InvalidOperationException($"Ledger with id {ledgerId.Value} not found.");
    }

    public Task<IReadOnlyList<Ledger>> GetAllAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<Ledger> result = [.. _ledgers.Values];
        return Task.FromResult(result);
    }
}
