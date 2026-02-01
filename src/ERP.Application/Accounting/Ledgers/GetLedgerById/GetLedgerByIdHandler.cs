using ERP.Domain.Accounting.Aggregates.Ledgers;

namespace ERP.Application.Accounting.Ledgers.GetLedgerById;

public sealed class GetLedgerByIdHandler(ILedgerRepository repository)
{
    private readonly ILedgerRepository _repository = repository;

    public async Task<LedgerDetailsDto> HandleAsync(GetLedgerByIdQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        Ledger ledger = await _repository.GetByIdAsync(query.LedgerId, cancellationToken);

        return new LedgerDetailsDto(
            Id: ledger.Id.ToString(),
            PeriodStart: ledger.Period.Start,
            PeriodEnd: ledger.Period.End,
            Status: ledger.Status.ToString(),
            ClosedAt: ledger.ClosedAt,
            JournalIds: [.. ledger.JournalIds.Select(id => id.ToString())]);
    }
}
