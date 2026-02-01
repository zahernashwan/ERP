using ERP.Domain.Accounting.Aggregates.Ledgers;

namespace ERP.Application.Accounting.Ledgers.OpenLedger;

public sealed class OpenLedgerHandler(ILedgerRepository ledgerRepository, IUnitOfWork unitOfWork)
{
    private readonly ILedgerRepository _ledgerRepository = ledgerRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(OpenLedgerCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var ledger = Ledger.Open(command.LedgerId, command.Period);

        await _ledgerRepository.AddAsync(ledger, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
