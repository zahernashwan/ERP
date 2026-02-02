namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidIssueTypeException(string message) : SetupDomainException(message);
