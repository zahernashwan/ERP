namespace ERP.Domain.Accounting.Exceptions;

public sealed class UnbalancedJournalException : DomainException
{
    public UnbalancedJournalException(decimal totalDebit, decimal totalCredit)
        : base($"Journal is unbalanced. Debit: {totalDebit}, Credit: {totalCredit}.")
    {
        TotalDebit = totalDebit;
        TotalCredit = totalCredit;
    }

    public decimal TotalDebit { get; }
    public decimal TotalCredit { get; }
}
