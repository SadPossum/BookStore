namespace BookStore.Api.Extensions;

using BookStore.Api.Abstractions;

public static class ModuleExtensions
{
    public static IEndpointRouteBuilder MapModuleEndpoints<TModule>(this IEndpointRouteBuilder endpointRouteBuilder)
        where TModule : IMinimalApiModule, new()
    {
        TModule module = new();

        module.AddRoutes(endpointRouteBuilder);

        return endpointRouteBuilder;
    }
}

