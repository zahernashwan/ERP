using ERP.Domain.Accounting.Exceptions;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Aggregates.Journals;

public sealed class JournalLine : Entity<Guid>
{
    private JournalLine(Guid id, AccountId accountId, Money debit, Money credit, string? description, ProjectId? projectId = null)
        : base(id)
    {
        AccountId = accountId;
        Debit = debit;
        Credit = credit;
        Description = description;
        ProjectId = projectId;
    }

    public AccountId AccountId { get; }
    public Money Debit { get; }
    public Money Credit { get; }
    public string? Description { get; }
    public ProjectId? ProjectId { get; }

    public static JournalLine CreateDebit(AccountId accountId, Money amount, string? description, ProjectId? projectId = null)
    {
        ValidateAccount(accountId);
        ValidateAmount(amount);

        if (amount.Amount == 0)
        {
            throw new InvalidJournalLineException("Debit amount must be greater than zero.");
        }

        return new JournalLine(Guid.NewGuid(), accountId, amount, Money.Zero(amount.Currency), description, projectId);
    }

    public static JournalLine CreateCredit(AccountId accountId, Money amount, string? description, ProjectId? projectId = null)
    {
        ValidateAccount(accountId);
        ValidateAmount(amount);

        if (amount.Amount == 0)
        {
            throw new InvalidJournalLineException("Credit amount must be greater than zero.");
        }

        return new JournalLine(Guid.NewGuid(), accountId, Money.Zero(amount.Currency), amount, description, projectId);
    }

    private static void ValidateAccount(AccountId accountId)
    {
        if (accountId is null)
        {
            throw new InvalidJournalLineException("Account is required for a journal line.");
        }
    }

    private static void ValidateAmount(Money amount)
    {
        if (amount is null)
        {
            throw new InvalidJournalLineException("Amount is required for a journal line.");
        }
    }
}
