using ERP.Application;
using ERP.Infrastructure;
using ERP.Presentation.WinForms;
using ERP.Presentation.WinForms.Accounting.ChartOfAccounts;
using ERP.Presentation.WinForms.Accounting.Journals;
using ERP.Presentation.WinForms.Accounting.Ledgers;
using ERP.Presentation.WinForms.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Bootstrapper;

public static class ContainerConfiguration
{
    public static IServiceProvider Configure()
    {
        var services = new ServiceCollection();

        // Register Layers
        services.AddApplication();
        services.AddInfrastructure();

        // Register Forms
        services.AddTransient<MainForm>();
        services.AddTransient<JournalsListForm>();
        services.AddTransient<JournalDetailsForm>();
        services.AddTransient<LedgersListForm>();
        services.AddTransient<ChartsListForm>();

        // Register Controllers
        services.AddTransient<JournalsController>();
        services.AddSingleton<INavigationController, NavigationController>();

        return services.BuildServiceProvider();
    }
}
