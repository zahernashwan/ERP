namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidGeneralSettingsException(string message) : SetupDomainException(message);
