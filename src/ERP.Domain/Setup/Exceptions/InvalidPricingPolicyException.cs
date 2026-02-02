namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidPricingPolicyException(string message) : SetupDomainException(message);
