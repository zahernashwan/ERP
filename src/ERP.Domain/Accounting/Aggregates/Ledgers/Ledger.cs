using ERP.Domain.Accounting.Events;
using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;
using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Domain.Accounting.Aggregates.Ledgers;

public sealed class Ledger : Entity<LedgerId>
{
    private readonly List<JournalId> _journalIds = new();
    private readonly List<DomainEvent> _domainEvents = new();

    private Ledger(LedgerId id, AccountingPeriod period)
        : base(id)
    {
        Period = period;
        Status = LedgerStatus.Open;
    }

    public AccountingPeriod Period { get; private set; }
    public LedgerStatus Status { get; private set; }
    public DateTimeOffset? ClosedAt { get; private set; }
    public IReadOnlyCollection<JournalId> JournalIds => _journalIds.AsReadOnly();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public static Ledger Open(LedgerId id, AccountingPeriod period)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (period is null)
        {
            throw new ArgumentNullException(nameof(period));
        }

        return new Ledger(id, period);
    }

    public void Register(Journal journal)
    {
        if (journal is null)
        {
            throw new ArgumentNullException(nameof(journal));
        }

        EnsureOpen();

        if (journal.Status != JournalStatus.Posted)
        {
            throw new UnpostedJournalException("Only posted journals can be registered in the ledger.");
        }

        if (!Period.Contains(journal.AccountingDate))
        {
            throw new JournalOutsidePeriodException("Journal accounting date must be within the ledger period.");
        }

        if (_journalIds.Contains(journal.Id))
        {
            throw new DuplicateJournalRegistrationException("Journal is already registered in this ledger.");
        }

        _journalIds.Add(journal.Id);
    }

    public void Close()
    {
        EnsureOpen();
        Status = LedgerStatus.Closed;
        ClosedAt = DateTimeOffset.UtcNow;
        _domainEvents.Add(new LedgerClosed(Id));
    }

    private void EnsureOpen()
    {
        if (Status != LedgerStatus.Open)
        {
            throw new LedgerClosedException("Ledger is closed and cannot accept new journals.");
        }
    }
}

public enum LedgerStatus
{
    Open,
    Closed
}
