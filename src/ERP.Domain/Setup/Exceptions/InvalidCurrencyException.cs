namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidCurrencyException(string message) : SetupDomainException(message);
