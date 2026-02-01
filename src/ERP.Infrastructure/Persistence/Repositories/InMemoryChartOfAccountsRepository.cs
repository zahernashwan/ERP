using ERP.Application.Accounting.ChartOfAccounts;
using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Infrastructure.Persistence.Repositories;

public sealed class InMemoryChartOfAccountsRepository : IChartOfAccountsRepository, IChartOfAccountsReadRepository
{
    private static readonly Dictionary<ChartOfAccountsId, ChartAggregate> _charts = [];

    public Task AddAsync(ChartAggregate chart, CancellationToken cancellationToken)
    {
        _charts[chart.Id] = chart;
        return Task.CompletedTask;
    }

    public Task<ChartAggregate> GetByIdAsync(ChartOfAccountsId chartId, CancellationToken cancellationToken)
    {
        if (_charts.TryGetValue(chartId, out var chart))
        {
            return Task.FromResult(chart);
        }

        throw new InvalidOperationException($"Chart of accounts with id {chartId.Value} not found.");
    }

    public Task<IReadOnlyList<ChartAggregate>> GetAllAsync(CancellationToken cancellationToken)
    {
        IReadOnlyList<ChartAggregate> result = [.. _charts.Values];
        return Task.FromResult(result);
    }
}
