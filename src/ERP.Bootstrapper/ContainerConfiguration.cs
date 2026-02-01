using ERP.Application;
using ERP.Infrastructure;
using ERP.Presentation.WinForms;
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
        // JournalForm is not yet fully implemented or registered as public in WinForms, so we skip it for now or register if needed.
        // services.AddTransient<JournalForm>();

        return services.BuildServiceProvider();
    }
}
