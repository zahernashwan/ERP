namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidInventoryExpiryPolicyException(string message) : SetupDomainException(message);
