using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Journals.GetJournalById;
using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.Journals.GetJournalById;

public sealed class GetJournalByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsJournalDetails()
    {
        var repo = new FakeJournalRepository();

        var journalId = JournalId.New();
        var journal = Journal.Start(journalId, JournalNumber.From("JV-0001"), new DateOnly(2026, 1, 1), "ref");
        await repo.AddAsync(journal, CancellationToken.None);

        var handler = new GetJournalByIdHandler(repo);
        var dto = await handler.HandleAsync(new GetJournalByIdQuery(journalId), CancellationToken.None);

        Assert.Equal(journalId.ToString(), dto.Id);
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
}
