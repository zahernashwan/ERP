using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Domain.Operations.Accounting.Events;

public sealed record ChartOpened(ChartOfAccountsId ChartId) : DomainEvent;
