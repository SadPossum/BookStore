namespace BookStore.Application.Books.Get;

using System.Threading.Tasks;
using BookStore.Domain.Books;
using MediatR;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
{
    private readonly IBookRepository bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository) => this.bookRepository = bookRepository;

    public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await this.bookRepository.GetBookAsync(request.Id);

        if (book == null)
        {
            return null;
        }

        var bookDto = new BookDto(book.Id, book.Title, book.ReleaseDate);

        return bookDto;
    }
}
