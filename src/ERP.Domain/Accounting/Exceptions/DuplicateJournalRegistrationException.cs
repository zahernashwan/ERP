namespace ERP.Domain.Accounting.Exceptions;

public sealed class DuplicateJournalRegistrationException : DomainException
{
    public DuplicateJournalRegistrationException(string message) : base(message)
    {
    }
}
