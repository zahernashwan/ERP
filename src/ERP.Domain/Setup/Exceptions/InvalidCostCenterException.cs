namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidCostCenterException(string message) : SetupDomainException(message);
