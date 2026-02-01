using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts;

public interface IChartOfAccountsRepository
{
    Task AddAsync(ChartAggregate chart, CancellationToken cancellationToken);
    Task<ChartAggregate> GetByIdAsync(ChartOfAccountsId chartId, CancellationToken cancellationToken);
}
