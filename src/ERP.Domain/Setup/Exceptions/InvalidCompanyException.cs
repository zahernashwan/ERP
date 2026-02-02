namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidCompanyException(string message) : SetupDomainException(message);
