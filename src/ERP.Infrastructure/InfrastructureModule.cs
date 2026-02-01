using ERP.Application;
using ERP.Application.Accounting.Journals;
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

        return services;
    }
}

