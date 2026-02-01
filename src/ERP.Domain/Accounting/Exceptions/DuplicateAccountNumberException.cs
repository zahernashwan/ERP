namespace ERP.Domain.Accounting.Exceptions;

public sealed class DuplicateAccountNumberException : DomainException
{
    public DuplicateAccountNumberException(string message) : base(message)
    {
    }
}
