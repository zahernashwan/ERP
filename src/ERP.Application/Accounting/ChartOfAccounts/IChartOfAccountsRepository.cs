using ChartAggregate = ERP.Domain.Operations.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts;

public interface IChartOfAccountsRepository
{
    Task AddAsync(ChartAggregate chart, CancellationToken cancellationToken);
    Task<ChartAggregate> GetByIdAsync(ChartOfAccountsId chartId, CancellationToken cancellationToken);
}
