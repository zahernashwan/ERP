namespace ERP.Domain.Accounting.Exceptions;

public sealed class UnpostedJournalException : DomainException
{
    public UnpostedJournalException(string message) : base(message)
    {
    }
}
