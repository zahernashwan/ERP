using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Ledgers.OpenLedger;

public sealed record OpenLedgerCommand(
    LedgerId LedgerId,
    AccountingPeriod Period
);
