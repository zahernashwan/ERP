namespace ERP.Domain.Accounting.Exceptions;

public sealed class InvalidJournalLineException : DomainException
{
    public InvalidJournalLineException(string message) : base(message)
    {
    }
}
