using ERP.Domain.Setup.Exceptions;
using ERP.Domain.Setup.System.ChartOfAccounts.Account;

namespace ERP.Domain.Setup.System.ChartOfAccounts.Policies;

public static class AccountNumberUniquenessPolicy
{
    public static void EnsureUnique(
        ChartOfAccountsId chartId,
        AccountNumber candidate,
        IReadOnlyCollection<AccountNumber> existingNumbers)
    {
        ArgumentNullException.ThrowIfNull(chartId);
        ArgumentNullException.ThrowIfNull(candidate);
        ArgumentNullException.ThrowIfNull(existingNumbers);

        if (existingNumbers.Any(n => n.Equals(candidate)))
        {
            throw new InvalidChartOfAccountsException($"Account number '{candidate.Value}' already exists in this chart.");
        }
    }
}
