namespace ERP.Application.Accounting.ChartOfAccounts.GetChartById;

public sealed record ChartDetailsDto(
    string Id,
    string Name,
    string Status,
    IReadOnlyList<AccountDto> Accounts
);

public sealed record AccountDto(
    string Id,
    string Number,
    string Name,
    string Type,
    bool IsActive
);
