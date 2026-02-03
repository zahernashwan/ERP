using ChartAggregate = ERP.Domain.Operations.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;

namespace ERP.Application.Accounting.ChartOfAccounts;

public interface IChartOfAccountsReadRepository
{
    Task<IReadOnlyList<ChartAggregate>> GetAllAsync(CancellationToken cancellationToken);
}
