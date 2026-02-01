namespace ERP.Application.Accounting.Journals.ListJournals;

public sealed class ListJournalsHandler(IJournalReadRepository repository)
{
    private readonly IJournalReadRepository _repository = repository;

    public async Task<IReadOnlyList<JournalListItemDto>> HandleAsync(ListJournalsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var journals = await _repository.GetAllAsync(cancellationToken);

        return
        [
            .. journals.Select(journal => new JournalListItemDto(
                Id: journal.Id.ToString(),
                Number: journal.Number.Value,
                AccountingDate: journal.AccountingDate,
                Status: journal.Status.ToString()))
        ];
    }
}
