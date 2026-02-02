using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals.GetJournalById;

public sealed class GetJournalByIdHandler(IJournalRepository repository)
{
    private readonly IJournalRepository _repository = repository;

    public async Task<JournalDetailsDto> HandleAsync(GetJournalByIdQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        Journal journal = await _repository.GetByIdAsync(query.JournalId, cancellationToken);

        var lines = journal.Lines
            .Select(line => new JournalLineDto(
                AccountId: line.AccountId.ToString(),
                Debit: line.Debit.Amount,
                Credit: line.Credit.Amount,
                Currency: line.Debit.Currency.Code,
                Description: line.Description,
                ProjectId: line.ProjectId?.ToString()))
            .ToList();

        return new JournalDetailsDto(
            Id: journal.Id.ToString(),
            Number: journal.Number.Value,
            AccountingDate: journal.AccountingDate,
            Reference: journal.Reference,
            Status: journal.Status.ToString(),
            PostedAt: journal.PostedAt,
            Lines: lines);
    }
}
