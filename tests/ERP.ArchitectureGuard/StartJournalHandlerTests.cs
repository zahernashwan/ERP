using ERP.Application;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.StartJournal;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.ArchitectureGuard;

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

        public Task AddAsync(Journal journal, CancellationToken cancellationToken)
        {
            Added = journal;
            return Task.CompletedTask;
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
