using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;

namespace ERP.Application.Accounting.ChartOfAccounts.OpenChart;

public sealed class OpenChartHandler(IChartOfAccountsRepository repository, IUnitOfWork unitOfWork)
{
    private readonly IChartOfAccountsRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task HandleAsync(OpenChartCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var chart = ChartAggregate.Open(command.ChartId, command.Name);

        await _repository.AddAsync(chart, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
