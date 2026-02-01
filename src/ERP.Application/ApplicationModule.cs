using Microsoft.Extensions.DependencyInjection;

namespace ERP.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register MediatR handlers
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
        });

        return services;
    }
}
