using ERP.Application;
using ERP.Application.Accounting.ChartOfAccounts;
using ERP.Application.Accounting.ChartOfAccounts.OpenChart;
using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.ChartOfAccounts.OpenChart;

public sealed class OpenChartHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_OpensChart()
    {
        var repo = new FakeChartRepository();
        var uow = new FakeUnitOfWork();

        var chartId = ChartOfAccountsId.New();
        var command = new OpenChartCommand(chartId, ChartName.From("Main Chart"));
        var handler = new OpenChartHandler(repo, uow);

        await handler.HandleAsync(command, CancellationToken.None);

        var chart = await repo.GetByIdAsync(chartId, CancellationToken.None);
        Assert.Equal(chartId, chart.Id);
        Assert.True(uow.Saved);
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

    private sealed class FakeUnitOfWork : IUnitOfWork
    {
        public bool Saved { get; private set; }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            Saved = true;
            return Task.CompletedTask;
        }
    }
}
