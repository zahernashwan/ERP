using ERP.Domain.Accounting.Aggregates.Journals;

namespace ERP.Application.Accounting.Journals.AddJournalLine;

public sealed class AddJournalLineHandler
{
    private readonly IJournalRepository _journalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddJournalLineHandler(IJournalRepository journalRepository, IUnitOfWork unitOfWork)
    {
        _journalRepository = journalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(AddJournalLineCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var journal = await _journalRepository.GetByIdAsync(command.JournalId, cancellationToken);

        if (command.IsDebit)
        {
            journal.AddDebit(command.AccountId, command.Amount, command.Description, command.ProjectId);
        }
        else
        {
            journal.AddCredit(command.AccountId, command.Amount, command.Description, command.ProjectId);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
