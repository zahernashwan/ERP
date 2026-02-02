namespace ERP.Application.Accounting.Ledgers.ListLedgers;

public sealed class ListLedgersHandler(ILedgerReadRepository repository)
{
    private readonly ILedgerReadRepository _repository = repository;

    public async Task<IReadOnlyList<LedgerListItemDto>> HandleAsync(ListLedgersQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var ledgers = await _repository.GetAllAsync(cancellationToken);

        return
        [
            .. ledgers.Select(ledger => new LedgerListItemDto(
                Id: ledger.Id.ToString(),
                PeriodStart: ledger.Period.Start,
                PeriodEnd: ledger.Period.End,
                Status: ledger.Status.ToString()))
        ];
    }
}
