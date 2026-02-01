using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Domain.Accounting.Events;

public sealed record LedgerClosed(LedgerId LedgerId) : DomainEvent;
