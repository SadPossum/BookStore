namespace BookStore.Api.Configurations;

using BookStore.Persistence;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Adds persistence services, such as database context and repositories.
        services.AddPersistence(configuration);

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCors();

        // Adds MediatR (mediator pattern implementation) services and automatically registers MediatR handlers 
        // from the Application layer.
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly));

        services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}
