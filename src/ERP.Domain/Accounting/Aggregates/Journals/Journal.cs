using ERP.Domain.Accounting.Events;
using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Aggregates.Journals;

public sealed class Journal : Entity<JournalId>
{
    private readonly List<JournalLine> _lines = new();
    private readonly List<DomainEvent> _domainEvents = new();
    private Currency? _currency;

    private Journal(JournalId id, JournalNumber number, DateOnly accountingDate, string? reference)
        : base(id)
    {
        Number = number;
        AccountingDate = accountingDate;
        Reference = reference;
        Status = JournalStatus.Draft;
    }

    public JournalNumber Number { get; private set; }
    public DateOnly AccountingDate { get; private set; }
    public string? Reference { get; private set; }
    public JournalStatus Status { get; private set; }
    public DateTimeOffset? PostedAt { get; private set; }
    public IReadOnlyCollection<JournalLine> Lines => _lines.AsReadOnly();
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public static Journal Start(JournalId id, JournalNumber number, DateOnly accountingDate, string? reference)
    {
        if (id is null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (number is null)
        {
            throw new ArgumentNullException(nameof(number));
        }

        if (accountingDate == default)
        {
            throw new ArgumentOutOfRangeException(nameof(accountingDate), "Accounting date is required.");
        }

        return new Journal(id, number, accountingDate, reference?.Trim());
    }

    public void AddDebit(AccountId accountId, Money amount, string? description = null, ProjectId? projectId = null)
    {
        EnsureDraft();
        var line = JournalLine.CreateDebit(accountId, amount, description, projectId);
        AddLine(line);
    }

    public void AddCredit(AccountId accountId, Money amount, string? description = null, ProjectId? projectId = null)
    {
        EnsureDraft();
        var line = JournalLine.CreateCredit(accountId, amount, description, projectId);
        AddLine(line);
    }

    public Money TotalDebit()
    {
        EnsureCurrencyDefined();
        var total = Money.Zero(_currency!);
        foreach (var line in _lines)
        {
            total = total.Add(line.Debit);
        }

        return total;
    }

    public Money TotalCredit()
    {
        EnsureCurrencyDefined();
        var total = Money.Zero(_currency!);
        foreach (var line in _lines)
        {
            total = total.Add(line.Credit);
        }

        return total;
    }

    public void Post()
    {
        EnsureDraft();
        if (_lines.Count == 0)
        {
            throw new InvalidJournalLineException("Journal must contain at least one line before posting.");
        }

        var debit = TotalDebit();
        var credit = TotalCredit();

        if (debit.Amount != credit.Amount)
        {
            throw new UnbalancedJournalException(debit.Amount, credit.Amount);
        }

        Status = JournalStatus.Posted;
        PostedAt = DateTimeOffset.UtcNow;
        _domainEvents.Add(new JournalPosted(Id));
    }

    private void AddLine(JournalLine line)
    {
        if (line is null)
        {
            throw new ArgumentNullException(nameof(line));
        }

        EnsureCurrency(line);
        _lines.Add(line);
    }

    private void EnsureCurrency(JournalLine line)
    {
        var lineCurrency = line.Debit.Currency.Equals(line.Credit.Currency)
            ? line.Debit.Currency
            : throw new InvalidJournalLineException("Debit and credit currency must match within a line.");

        if (_currency is null)
        {
            _currency = lineCurrency;
            return;
        }

        if (!_currency.Equals(lineCurrency))
        {
            throw new InvalidJournalLineException("All journal lines must use the same currency.");
        }
    }

    private void EnsureCurrencyDefined()
    {
        if (_currency is null)
        {
            throw new InvalidJournalLineException("Journal currency is not defined yet.");
        }
    }

    private void EnsureDraft()
    {
        if (Status != JournalStatus.Draft)
        {
            throw new InvalidOperationException("Only draft journals can be modified.");
        }
    }
}

public enum JournalStatus
{
    Draft,
    Posted
}
