namespace BookStore.Api.Endpoints;

using BookStore.Api.Abstractions;
using BookStore.Api.Models;
using BookStore.Application.Orders.Create;
using BookStore.Application.Orders.Get;
using BookStore.Domain.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class Orders : IMinimalApiModule
{
    public void AddRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapPost("/api/orders", async ([FromBody] CreateOrderCommand command, IMediator mediator) =>
        {
            await mediator.Send(command);

            return Results.Ok();
        });

        endpointRouteBuilder.MapGet("/api/orders", async ([AsParameters] GetOrdersRequest request, IMediator mediator) =>
        {
            var getOrdersQuery = new GetOrdersQuery()
            {
                OrderNumber = request?.OrderNumberSearch,
                OrderDate = request?.OrderDateSearch,
            };

            (var entries, var count, var totalCount) = await mediator.Send(getOrdersQuery);

            var result = new ListResponse<OrderDto>()
            {
                Items = entries,
                ItemsCount = count,
                TotalItemsCount = totalCount,
            };

            return Results.Ok(result);
        });
    }
}

