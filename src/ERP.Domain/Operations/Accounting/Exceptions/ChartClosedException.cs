namespace ERP.Domain.Operations.Accounting.Exceptions;

public sealed class ChartClosedException : DomainException
{
    public ChartClosedException(string message) : base(message)
    {
    }
}
