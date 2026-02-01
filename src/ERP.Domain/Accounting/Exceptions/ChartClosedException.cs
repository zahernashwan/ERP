namespace ERP.Domain.Accounting.Exceptions;

public sealed class ChartClosedException : DomainException
{
    public ChartClosedException(string message) : base(message)
    {
    }
}
