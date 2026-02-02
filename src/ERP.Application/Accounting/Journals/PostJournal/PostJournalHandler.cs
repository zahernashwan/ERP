using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals.PostJournal;

public sealed class PostJournalHandler
{
    private readonly IJournalRepository _journalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostJournalHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork)
    {
        _journalRepository = journalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(PostJournalCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var journal = await _journalRepository.GetByIdAsync(command.JournalId, cancellationToken);

        journal.Post();

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
