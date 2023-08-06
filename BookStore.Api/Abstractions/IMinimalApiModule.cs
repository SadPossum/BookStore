namespace BookStore.Api.Abstractions;

// Interface representing a minimal API module that can be added to the application.
public interface IMinimalApiModule
{
    // Method for adding routes to the API module.
    // The IEndpointRouteBuilder parameter allows configuring API endpoints and routes.
    void AddRoutes(IEndpointRouteBuilder endpointRouteBuilder);
}

