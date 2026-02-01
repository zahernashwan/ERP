using ERP.Domain.Accounting.Aggregates.Accounts;
using ERP.Domain.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts.RegisterAccount;

public sealed record RegisterAccountCommand(
    ChartOfAccountsId ChartId,
    AccountNumber Number,
    AccountName Name,
    AccountType Type
);
