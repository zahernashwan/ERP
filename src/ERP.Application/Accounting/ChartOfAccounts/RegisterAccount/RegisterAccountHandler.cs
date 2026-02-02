namespace ERP.Application.Accounting.ChartOfAccounts.RegisterAccount;

public sealed class RegisterAccountHandler(IChartOfAccountsRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IChartOfAccountsRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(RegisterAccountCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var chart = await _repository.GetByIdAsync(command.ChartId, cancellationToken);

        chart.RegisterAccount(command.Number, command.Name, command.Type);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
