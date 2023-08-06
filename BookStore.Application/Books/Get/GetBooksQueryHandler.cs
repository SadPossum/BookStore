namespace BookStore.Application.Books.Get;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Books;
using MediatR;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, (IEnumerable<BookDto> Entries, int Count, int TotalCount)>
{
    private readonly IBookRepository bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository) => this.bookRepository = bookRepository;

    public async Task<(IEnumerable<BookDto> Entries, int Count, int TotalCount)> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var (entries, count, totalCount) = await this.bookRepository.GetBooksAsync(
            request.Title,
            request.ReleaseDate);

        var bookDtoList = entries.Select(a =>
            new BookDto(
                a.Id,
                a.Title,
                a.ReleaseDate));

        return (bookDtoList, count, totalCount);
    }
}
