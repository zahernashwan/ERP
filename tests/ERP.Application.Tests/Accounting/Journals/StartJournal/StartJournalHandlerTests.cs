using ERP.Application;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.StartJournal;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Journals.StartJournal;

public sealed class StartJournalHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_PersistsJournal()
    {
        var repo = new FakeJournalRepository();
        var uow = new FakeUnitOfWork();
        var handler = new StartJournalHandler(repo, uow);

        var command = new StartJournalCommand(
            JournalId.New(),
            JournalNumber.From("JV-0001"),
            new DateOnly(2026, 1, 1),
            "ref");

        await handler.HandleAsync(command, CancellationToken.None);

        Assert.NotNull(repo.Added);
        Assert.Equal(command.Id, repo.Added!.Id);
        Assert.True(uow.Saved);
    }

    private sealed class FakeJournalRepository : IJournalRepository
    {
        public Journal? Added { get; private set; }
        private readonly Dictionary<JournalId, Journal> _journals = [];

        public Task AddAsync(Journal journal, CancellationToken cancellationToken)
        {
            Added = journal;
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
