namespace ERP.Domain.Accounting.Exceptions;

public sealed class LedgerClosedException : DomainException
{
    public LedgerClosedException(string message) : base(message)
    {
    }
}
