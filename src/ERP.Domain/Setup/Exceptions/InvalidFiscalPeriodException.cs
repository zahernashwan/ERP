namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidFiscalPeriodException(string message) : SetupDomainException(message);
