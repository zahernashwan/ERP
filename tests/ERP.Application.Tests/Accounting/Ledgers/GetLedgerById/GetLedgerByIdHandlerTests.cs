using ERP.Application.Accounting.Ledgers;
using ERP.Application.Accounting.Ledgers.GetLedgerById;
using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Ledgers.GetLedgerById;

public sealed class GetLedgerByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsLedgerDetails()
    {
        var repo = new FakeLedgerRepository();

        var ledgerId = LedgerId.New();
        var period = AccountingPeriod.Create(new DateOnly(2026, 1, 1), new DateOnly(2026, 12, 31));
        var ledger = Ledger.Open(ledgerId, period);
        await repo.AddAsync(ledger, CancellationToken.None);

        var handler = new GetLedgerByIdHandler(repo);
        var dto = await handler.HandleAsync(new GetLedgerByIdQuery(ledgerId), CancellationToken.None);

        Assert.Equal(ledgerId.ToString(), dto.Id);
    }

    private sealed class FakeLedgerRepository : ILedgerRepository
    {
        private readonly Dictionary<LedgerId, Ledger> _ledgers = [];

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

            throw new KeyNotFoundException($"Ledger with ID {ledgerId} not found.");
        }
    }
}
