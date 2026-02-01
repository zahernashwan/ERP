using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals.StartJournal;

public sealed class StartJournalHandler
{
    private readonly IJournalRepository _journalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StartJournalHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork)
    {
        _journalRepository = journalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(StartJournalCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var journal = Journal.Start(
            command.Id,
            command.Number,
            command.AccountingDate,
            command.Reference);

        await _journalRepository.AddAsync(journal, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
