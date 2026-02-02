namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidSupplyTypeException(string message) : SetupDomainException(message);
