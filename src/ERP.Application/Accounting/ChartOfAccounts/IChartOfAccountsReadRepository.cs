using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;

namespace ERP.Application.Accounting.ChartOfAccounts;

public interface IChartOfAccountsReadRepository
{
    Task<IReadOnlyList<ChartAggregate>> GetAllAsync(CancellationToken cancellationToken);
}
