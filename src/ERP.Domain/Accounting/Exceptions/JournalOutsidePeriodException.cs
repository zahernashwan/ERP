namespace ERP.Domain.Accounting.Exceptions;

public sealed class JournalOutsidePeriodException : DomainException
{
    public JournalOutsidePeriodException(string message) : base(message)
    {
    }
}
