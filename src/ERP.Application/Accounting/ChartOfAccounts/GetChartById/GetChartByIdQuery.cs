using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts.GetChartById;

public sealed record GetChartByIdQuery(ChartOfAccountsId ChartId);
