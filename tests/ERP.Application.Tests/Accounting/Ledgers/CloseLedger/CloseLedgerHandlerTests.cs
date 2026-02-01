using ERP.Application;
using ERP.Application.Accounting.Ledgers;
using ERP.Application.Accounting.Ledgers.CloseLedger;
using ERP.Application.Accounting.Ledgers.OpenLedger;
using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Ledgers.CloseLedger;

public sealed class CloseLedgerHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ClosesLedger()
    {
        var repo = new FakeLedgerRepository();
        var uow = new FakeUnitOfWork();

        var ledgerId = LedgerId.New();
        var period = AccountingPeriod.Create(new DateOnly(2026, 1, 1), new DateOnly(2026, 12, 31));
        var open = new OpenLedgerHandler(repo, uow);
        await open.HandleAsync(new OpenLedgerCommand(ledgerId, period), CancellationToken.None);

        uow.Reset();
        var handler = new CloseLedgerHandler(repo, uow);

        await handler.HandleAsync(new CloseLedgerCommand(ledgerId), CancellationToken.None);

        var ledger = await repo.GetByIdAsync(ledgerId, CancellationToken.None);
        Assert.Equal(LedgerStatus.Closed, ledger.Status);
        Assert.True(uow.Saved);
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

    private sealed class FakeUnitOfWork : IUnitOfWork
    {
        public bool Saved { get; private set; }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            Saved = true;
            return Task.CompletedTask;
        }

        public void Reset() => Saved = false;
    }
}
