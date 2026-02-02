using ERP.Domain.Accounting.Aggregates.Journals;
using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Domain.Tests.Accounting.Journals;

public sealed class JournalTests
{
    [Fact]
    public void Start_WithDefaultAccountingDate_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Journal.Start(JournalId.New(), JournalNumber.From("JV-1"), default, null));
    }

    [Fact]
    public void Post_WithNoLines_Throws()
    {
        var journal = Journal.Start(JournalId.New(), JournalNumber.From("JV-1"), new DateOnly(2026, 1, 1), null);

        Assert.Throws<InvalidJournalLineException>(() => journal.Post());
    }

    [Fact]
    public void Post_WithUnbalancedTotals_Throws()
    {
        var journal = Journal.Start(JournalId.New(), JournalNumber.From("JV-1"), new DateOnly(2026, 1, 1), null);
        var accountId = AccountId.New();
        var currency = Currency.FromCode("USD");

        journal.AddDebit(accountId, new Money(10m, currency));
        journal.AddCredit(accountId, new Money(5m, currency));

        Assert.Throws<UnbalancedJournalException>(() => journal.Post());
    }

    [Fact]
    public void Post_WhenBalanced_SetsStatusToPosted()
    {
        var journal = Journal.Start(JournalId.New(), JournalNumber.From("JV-1"), new DateOnly(2026, 1, 1), null);
        var accountId = AccountId.New();
        var currency = Currency.FromCode("USD");

        journal.AddDebit(accountId, new Money(10m, currency));
        journal.AddCredit(accountId, new Money(10m, currency));

        journal.Post();

        Assert.Equal(JournalStatus.Posted, journal.Status);
    }
}
