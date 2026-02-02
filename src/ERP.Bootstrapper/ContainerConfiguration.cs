using ERP.Application;
using ERP.Infrastructure;
using ERP.Presentation.WinForms;
using ERP.Presentation.WinForms.Accounting.ChartOfAccounts;
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
        services.AddTransient<ChartsListForm>();

        // Register Controllers
        services.AddSingleton<INavigationController, NavigationController>();

        return services.BuildServiceProvider();
    }
}
