using ERP.Application.Accounting.ChartOfAccounts;
using ERP.Application.Accounting.ChartOfAccounts.ListCharts;
using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.ChartOfAccounts.ListCharts;

public sealed class ListChartsHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_ReturnsAllCharts()
    {
        var repo = new FakeChartReadRepository();

        repo.Add(ChartAggregate.Open(ChartOfAccountsId.New(), ChartName.From("Main")));

        var handler = new ListChartsHandler(repo);
        var list = await handler.HandleAsync(new ListChartsQuery(), CancellationToken.None);

        Assert.Single(list);
    }

    private sealed class FakeChartReadRepository : IChartOfAccountsReadRepository
    {
        private readonly List<ChartAggregate> _charts = [];

        public Task<IReadOnlyList<ChartAggregate>> GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<ChartAggregate>)_charts);

        public void Add(ChartAggregate chart) => _charts.Add(chart);
    }
}
