using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Ledgers.CloseLedger;

public sealed record CloseLedgerCommand(LedgerId LedgerId);
