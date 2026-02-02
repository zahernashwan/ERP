namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidBranchException(string message) : SetupDomainException(message);
