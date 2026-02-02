namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidTransferTypeException(string message) : SetupDomainException(message);
