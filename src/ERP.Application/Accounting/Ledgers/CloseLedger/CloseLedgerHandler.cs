namespace ERP.Application.Accounting.Ledgers.CloseLedger;

public sealed class CloseLedgerHandler(ILedgerRepository ledgerRepository, IUnitOfWork unitOfWork)
{
    private readonly ILedgerRepository _ledgerRepository = ledgerRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(CloseLedgerCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var ledger = await _ledgerRepository.GetByIdAsync(command.LedgerId, cancellationToken);
        ledger.Close();

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
