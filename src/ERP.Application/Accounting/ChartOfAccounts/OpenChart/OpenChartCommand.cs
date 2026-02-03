using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts.OpenChart;

public sealed record OpenChartCommand(
    ChartOfAccountsId ChartId,
    ChartName Name
);
