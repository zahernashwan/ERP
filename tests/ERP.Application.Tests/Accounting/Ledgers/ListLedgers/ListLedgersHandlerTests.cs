using ERP.Application.Accounting.Ledgers;
using ERP.Application.Accounting.Ledgers.ListLedgers;
using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Ledgers.ListLedgers;

public sealed class ListLedgersHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsAllLedgers()
    {
        var repo = new FakeLedgerReadRepository();

        var ledgerId = LedgerId.New();
        var period = AccountingPeriod.Create(new DateOnly(2026, 1, 1), new DateOnly(2026, 12, 31));
        repo.Add(Ledger.Open(ledgerId, period));

        var handler = new ListLedgersHandler(repo);
        var list = await handler.HandleAsync(new ListLedgersQuery(), CancellationToken.None);

        Assert.Single(list);
    }

    private sealed class FakeLedgerReadRepository : ILedgerReadRepository
    {
        private readonly List<Ledger> _ledgers = [];

        public Task<IReadOnlyList<Ledger>> GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<Ledger>)_ledgers);

        public void Add(Ledger ledger) => _ledgers.Add(ledger);
    }
}
