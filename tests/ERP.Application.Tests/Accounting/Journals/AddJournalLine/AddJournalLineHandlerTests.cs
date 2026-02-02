using ERP.Application;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.AddJournalLine;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Journals.AddJournalLine;

public sealed class AddJournalLineHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenDebit_AddsDebitLine()
    {
        var repo = new FakeJournalRepository();
        var uow = new FakeUnitOfWork();

        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-0001"), new DateOnly(2026, 1, 1), "ref");
        await repo.AddAsync(journal, CancellationToken.None);

        var handler = new AddJournalLineHandler(repo, uow);
        var accountId = AccountId.New();
        var currency = Currency.FromCode("USD");
        var amount = new Money(150m, currency);
        var command = new AddJournalLineCommand(journalId, accountId, amount, true, "Test debit", null);

        await handler.HandleAsync(command, CancellationToken.None);

        var updatedJournal = await repo.GetByIdAsync(journalId, CancellationToken.None);
        Assert.Single(updatedJournal.Lines);
        Assert.Equal(amount.Amount, updatedJournal.Lines.First().Debit.Amount);
        Assert.True(uow.Saved);
    }

    [Fact]
    public async Task HandleAsync_WhenCredit_AddsCreditLine()
    {
        var repo = new FakeJournalRepository();
        var uow = new FakeUnitOfWork();

        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-0002"), new DateOnly(2026, 1, 2), "ref");
        await repo.AddAsync(journal, CancellationToken.None);

        var handler = new AddJournalLineHandler(repo, uow);
        var accountId = AccountId.New();
        var currency = Currency.FromCode("USD");
        var amount = new Money(200m, currency);
        var command = new AddJournalLineCommand(journalId, accountId, amount, false, "Test credit", null);

        await handler.HandleAsync(command, CancellationToken.None);

        var updatedJournal = await repo.GetByIdAsync(journalId, CancellationToken.None);
        Assert.Single(updatedJournal.Lines);
        Assert.Equal(amount.Amount, updatedJournal.Lines.First().Credit.Amount);
        Assert.True(uow.Saved);
    }

    [Fact]
    public async Task HandleAsync_WithProjectId_AddsLineWithProject()
    {
        var repo = new FakeJournalRepository();
        var uow = new FakeUnitOfWork();

        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-0003"), new DateOnly(2026, 1, 3), "ref");
        await repo.AddAsync(journal, CancellationToken.None);

        var handler = new AddJournalLineHandler(repo, uow);
        var accountId = AccountId.New();
        var projectId = ProjectId.New();
        var currency = Currency.FromCode("USD");
        var amount = new Money(300m, currency);
        var command = new AddJournalLineCommand(journalId, accountId, amount, true, "Project expense", projectId);

        await handler.HandleAsync(command, CancellationToken.None);

        var updatedJournal = await repo.GetByIdAsync(journalId, CancellationToken.None);
        Assert.Single(updatedJournal.Lines);
        Assert.Equal(projectId, updatedJournal.Lines.First().ProjectId);
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

    private sealed class FakeUnitOfWork : IUnitOfWork
    {
        public bool Saved { get; private set; }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            Saved = true;
            return Task.CompletedTask;
        }
    }
}
