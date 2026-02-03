using ERP.Domain.Operations.Accounting.Aggregates.Accounts;
using ERP.Domain.Operations.Accounting.ValueObjects;

namespace ERP.Application.Accounting.ChartOfAccounts.RegisterAccount;

public sealed record RegisterAccountCommand(
    ChartOfAccountsId ChartId,
    AccountNumber Number,
    AccountName Name,
    AccountType Type
);
