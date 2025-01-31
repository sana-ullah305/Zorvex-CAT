using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zorvex.Domain.Contracts;
using Zorvex.Infrastructure.Data;
using Zorvex.Infrastructure.Repositories;

namespace Zorvex.Application;
// ApplicationServiceExtensions.cs
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly));
        return services;
    }
}

// InfrastructureServiceExtensions.cs

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Register DbContext (Scoped as it should be created per request)
        services.AddScoped<DapperDbContext>();

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();

        // Register connection string (use Singleton if it doesn't need to change per request)
        services.AddSingleton(new ConnectionString(configuration.GetConnectionString("Default")));

        // Additional infrastructure services could go here (e.g., file storage, external APIs)

        return services;
    }
}