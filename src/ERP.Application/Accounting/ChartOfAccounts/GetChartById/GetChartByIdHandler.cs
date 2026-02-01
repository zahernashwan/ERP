using ChartAggregate = ERP.Domain.Accounting.Aggregates.ChartOfAccounts.ChartOfAccounts;

namespace ERP.Application.Accounting.ChartOfAccounts.GetChartById;

public sealed class GetChartByIdHandler(IChartOfAccountsRepository repository)
{
    private readonly IChartOfAccountsRepository _repository = repository;

    public async Task<ChartDetailsDto> HandleAsync(GetChartByIdQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        ChartAggregate chart = await _repository.GetByIdAsync(query.ChartId, cancellationToken);

        var accounts = chart.Accounts
            .Select(account => new AccountDto(
                Id: account.Id.ToString(),
                Number: account.Number.Value,
                Name: account.Name.Value,
                Type: account.Type.ToString(),
                IsActive: account.IsActive))
            .ToList();

        return new ChartDetailsDto(
            Id: chart.Id.ToString(),
            Name: chart.Name.Value,
            Status: chart.Status.ToString(),
            Accounts: accounts);
    }
}
