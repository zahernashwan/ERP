using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Events;

public sealed record AccountDeactivated(AccountId AccountId) : DomainEvent;
