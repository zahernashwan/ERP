using ERP.Application;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.StartJournal;
using ERP.Application.Accounting.Ledgers;
using ERP.Application.Accounting.Ledgers.OpenLedger;
using ERP.Application.Accounting.Ledgers.RegisterJournal;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.Aggregates.Ledgers;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Ledgers.RegisterJournal;

public sealed class RegisterJournalHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_RegistersJournalInLedger()
    {
        var journals = new FakeJournalRepository();
        var ledgers = new FakeLedgerRepository();
        var uow = new FakeUnitOfWork();

        var ledgerId = LedgerId.New();
        var period = AccountingPeriod.Create(new DateOnly(2026, 1, 1), new DateOnly(2026, 12, 31));
        var openLedger = new OpenLedgerHandler(ledgers, uow);
        await openLedger.HandleAsync(new OpenLedgerCommand(ledgerId, period), CancellationToken.None);

        var journalId = JournalId.New();
        var startJournal = new StartJournalHandler(journals, uow);
        await startJournal.HandleAsync(new StartJournalCommand(journalId, JournalNumber.From("JV-1"), new DateOnly(2026, 1, 1), null), CancellationToken.None);

        // Post it so ledger invariants allow registration.
        var journal = await journals.GetByIdAsync(journalId, CancellationToken.None);
        var accountId = AccountId.New();
        var currency = Currency.FromCode("USD");
        var amount = new Money(10m, currency);
        journal.AddDebit(accountId, amount);
        journal.AddCredit(accountId, amount);
        journal.Post();

        uow.Reset();
        var handler = new RegisterJournalHandler(ledgers, journals, uow);
        await handler.HandleAsync(new RegisterJournalCommand(ledgerId, journalId), CancellationToken.None);

        var ledger = await ledgers.GetByIdAsync(ledgerId, CancellationToken.None);
        Assert.Single(ledger.JournalIds);
        Assert.True(uow.Saved);
    }

    private sealed class FakeJournalRepository : IJournalRepository
    {
        private readonly Dictionary<JournalId, Journal> _journals = [];

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

            throw new KeyNotFoundException($"Journal with ID {journalId} not found.");
        }
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
