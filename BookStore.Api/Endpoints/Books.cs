namespace BookStore.Api.Endpoints;

using BookStore.Api.Abstractions;
using BookStore.Api.Models;
using BookStore.Application.Books.Get;
using BookStore.Domain.Books;
using BookStore.Domain.Entities;
using MediatR;

public class Books : IMinimalApiModule
{
    public void AddRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/api/books", async ([AsParameters] GetBookRequest request, IMediator mediator) =>
        {
            var getBookQuery = new GetBooksQuery()
            {
                Title = request?.TitleSearch,
                ReleaseDate = request?.ReleaseDateSearch,
            };

            (var entries, var count, var totalCount) = await mediator.Send(getBookQuery);

            var result = new ListResponse<BookDto>()
            {
                Items = entries,
                ItemsCount = count,
                TotalItemsCount = totalCount,
            };

            return Results.Ok(result);
        });

        endpointRouteBuilder.MapGet("/api/books/{id}", async (int id, IMediator mediator) =>
        {
            var query = new GetBookByIdQuery() { Id = id };

            var result = await mediator.Send(query) ??
                throw new KeyNotFoundException($"{nameof(Book)} with id {id} not found");

            return Results.Ok(result);
        });
    }
}

