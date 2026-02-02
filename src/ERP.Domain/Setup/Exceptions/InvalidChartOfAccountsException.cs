namespace ERP.Domain.Setup.Exceptions;

public sealed class InvalidChartOfAccountsException(string message) : SetupDomainException(message);
