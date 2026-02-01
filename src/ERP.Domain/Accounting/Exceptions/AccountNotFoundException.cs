namespace ERP.Domain.Accounting.Exceptions;

public sealed class AccountNotFoundException : DomainException
{
    public AccountNotFoundException(string message) : base(message)
    {
    }
}
