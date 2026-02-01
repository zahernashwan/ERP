using ERP.Application;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.PostJournal;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.ArchitectureGuard;

public sealed class PostJournalHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_PostsJournal()
    {
        var repo = new FakeJournalRepository();
        var uow = new FakeUnitOfWork();
        
        // First create a journal with some lines
        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-0001"), new DateOnly(2026, 1, 1), "ref");
        var accountId = AccountId.New();
        var amount = Money.FromDecimal(100, Currency.USD);
        journal.AddDebit(accountId, amount, "Test debit");
        journal.AddCredit(accountId, amount, "Test credit");
        await repo.AddAsync(journal, CancellationToken.None);

        var handler = new PostJournalHandler(repo, uow);
        var command = new PostJournalCommand(journalId);

        await handler.HandleAsync(command, CancellationToken.None);

        var postedJournal = await repo.GetByIdAsync(journalId, CancellationToken.None);
        Assert.Equal(JournalStatus.Posted, postedJournal.Status);
        Assert.NotNull(postedJournal.PostedAt);
        Assert.True(uow.Saved);
    }

    private sealed class FakeJournalRepository : IJournalRepository
    {
        private readonly Dictionary<JournalId, Journal> _journals = new();

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
