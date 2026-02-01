using ERP.Application;
using ERP.Application.Accounting.ChartOfAccounts;
using ERP.Application.Accounting.ChartOfAccounts.OpenChart;
using ERP.Application.Accounting.ChartOfAccounts.RegisterAccount;
using ERP.Domain.Accounting.Aggregates.Accounts;
using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;
using ERP.Domain.Accounting.ValueObjects;
using Xunit;

namespace ERP.Application.Tests.Accounting.ChartOfAccounts.RegisterAccount;

public sealed class RegisterAccountHandlerTests
{
    [Fact]
    public async Task HandleAsync_WhenCalled_RegistersAccount()
    {
        var repo = new FakeChartRepository();
        var uow = new FakeUnitOfWork();

        var chartId = ChartOfAccountsId.New();
        var open = new OpenChartHandler(repo, uow);
        await open.HandleAsync(new OpenChartCommand(chartId, ChartName.From("Main")), CancellationToken.None);

        uow.Reset();
        var handler = new RegisterAccountHandler(repo, uow);
        var command = new RegisterAccountCommand(
            chartId,
            AccountNumber.From("1000"),
            AccountName.From("Cash"),
            AccountType.Asset);

        await handler.HandleAsync(command, CancellationToken.None);

        var chart = await repo.GetByIdAsync(chartId, CancellationToken.None);
        Assert.Single(chart.Accounts);
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

        public void Reset() => Saved = false;
    }
}
