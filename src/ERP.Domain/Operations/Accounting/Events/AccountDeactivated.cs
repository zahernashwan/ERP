using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Domain.Operations.Accounting.Events;

public sealed record AccountDeactivated(AccountId AccountId) : DomainEvent;
