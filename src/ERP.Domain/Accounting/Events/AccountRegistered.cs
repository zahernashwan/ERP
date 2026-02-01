using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Events;

public sealed record AccountRegistered(AccountId AccountId, AccountNumber Number) : DomainEvent;
