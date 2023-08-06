namespace BookStore.Application.Books.Get;

using BookStore.Domain.Books;
using MediatR;

public class GetBookByIdQuery : IRequest<BookDto?>
{
    public int Id { get; set; }
}
