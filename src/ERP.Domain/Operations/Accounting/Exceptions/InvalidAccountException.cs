namespace ERP.Domain.Operations.Accounting.Exceptions;

public sealed class InvalidAccountException : DomainException
{
    public InvalidAccountException(string message)
        : base(message)
    {
    }
}
