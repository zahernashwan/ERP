using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.ListJournals;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Journals.ListJournals;

public sealed class ListJournalsHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsAllJournals()
    {
        var repo = new FakeJournalReadRepository();

        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-1"), new DateOnly(2026, 1, 1), null);
        repo.Add(journal);

        var handler = new ListJournalsHandler(repo);
        var list = await handler.HandleAsync(new ListJournalsQuery(), CancellationToken.None);

        Assert.Single(list);
    }

    private sealed class FakeJournalReadRepository : IJournalReadRepository
    {
        private readonly List<Journal> _journals = [];

        public Task<IReadOnlyList<Journal>> GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<Journal>)_journals);

        public void Add(Journal journal) => _journals.Add(journal);
    }
}
