namespace ERP.Domain.Operations.Accounting.Exceptions;

public sealed class DuplicateAccountNumberException : DomainException
{
    public DuplicateAccountNumberException(string message) : base(message)
    {
    }
}
