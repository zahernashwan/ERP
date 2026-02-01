using ERP.Application;
using ERP.Application.Accounting.ChartOfAccounts;
using ERP.Application.Accounting.Journals;
using ERP.Application.Accounting.Ledgers;
using ERP.Infrastructure.Persistence;
using ERP.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, InMemoryUnitOfWork>();
        services.AddSingleton<IJournalRepository, InMemoryJournalRepository>();
        services.AddSingleton<IJournalReadRepository>(sp => (IJournalReadRepository)sp.GetRequiredService<IJournalRepository>());

        services.AddSingleton<IChartOfAccountsRepository, InMemoryChartOfAccountsRepository>();
        services.AddSingleton<IChartOfAccountsReadRepository>(sp => (IChartOfAccountsReadRepository)sp.GetRequiredService<IChartOfAccountsRepository>());

        services.AddSingleton<ILedgerRepository, InMemoryLedgerRepository>();
        services.AddSingleton<ILedgerReadRepository>(sp => (ILedgerReadRepository)sp.GetRequiredService<ILedgerRepository>());

        return services;
    }
}

