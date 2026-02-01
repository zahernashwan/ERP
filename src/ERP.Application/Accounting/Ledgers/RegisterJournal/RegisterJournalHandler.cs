using ERP.Application.Accounting.Journals;

namespace ERP.Application.Accounting.Ledgers.RegisterJournal;

public sealed class RegisterJournalHandler(ILedgerRepository ledgerRepository, IJournalRepository journalRepository, IUnitOfWork unitOfWork)
{
    private readonly ILedgerRepository _ledgerRepository = ledgerRepository;
    private readonly IJournalRepository _journalRepository = journalRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(RegisterJournalCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var ledger = await _ledgerRepository.GetByIdAsync(command.LedgerId, cancellationToken);
        var journal = await _journalRepository.GetByIdAsync(command.JournalId, cancellationToken);

        ledger.Register(journal);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
