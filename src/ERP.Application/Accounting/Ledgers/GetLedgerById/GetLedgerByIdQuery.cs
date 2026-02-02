using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.Ledgers.GetLedgerById;

public sealed record GetLedgerByIdQuery(LedgerId LedgerId);
