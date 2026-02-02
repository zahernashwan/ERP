namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidAccountException(string message) : SetupDomainException(message);
