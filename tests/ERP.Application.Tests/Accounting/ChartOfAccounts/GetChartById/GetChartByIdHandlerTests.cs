using ERP.Application.Accounting.ChartOfAccounts;
using ERP.Application.Accounting.ChartOfAccounts.GetChartById;
using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.ChartOfAccounts.GetChartById;

public sealed class GetChartByIdHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsChartDetails()
    {
        var repo = new FakeChartRepository();

        var chartId = ChartOfAccountsId.New();
        var chart = ChartAggregate.Open(chartId, ChartName.From("Main"));
        await repo.AddAsync(chart, CancellationToken.None);

        var handler = new GetChartByIdHandler(repo);
        var dto = await handler.HandleAsync(new GetChartByIdQuery(chartId), CancellationToken.None);

        Assert.Equal(chartId.ToString(), dto.Id);
    }

    private sealed class FakeChartRepository : IChartOfAccountsRepository
    {
        private readonly Dictionary<ChartOfAccountsId, ChartAggregate> _charts = [];

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

            throw new KeyNotFoundException($"Chart with ID {chartId} not found.");
        }
    }
}
