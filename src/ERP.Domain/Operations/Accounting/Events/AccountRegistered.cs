using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Domain.Operations.Accounting.Events;

public sealed record AccountRegistered(AccountId AccountId, AccountNumber Number) : DomainEvent;
