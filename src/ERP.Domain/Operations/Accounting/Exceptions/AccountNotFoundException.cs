namespace ERP.Domain.Operations.Accounting.Exceptions;

public sealed class AccountNotFoundException : DomainException
{
    public AccountNotFoundException(string message) : base(message)
    {
    }
}
