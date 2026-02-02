namespace ERP.Application.Accounting.ChartOfAccounts.ListCharts;

public sealed class ListChartsHandler(IChartOfAccountsReadRepository repository)
{
    private readonly IChartOfAccountsReadRepository _repository = repository;

    public async Task<IReadOnlyList<ChartListItemDto>> HandleAsync(ListChartsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var charts = await _repository.GetAllAsync(cancellationToken);

        return
        [
            .. charts.Select(chart => new ChartListItemDto(
                Id: chart.Id.ToString(),
                Name: chart.Name.Value,
                Status: chart.Status.ToString()))
        ];
    }
}
