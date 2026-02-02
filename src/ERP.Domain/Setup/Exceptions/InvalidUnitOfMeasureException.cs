namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidUnitOfMeasureException(string message) : SetupDomainException(message);
