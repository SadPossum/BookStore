namespace BookStore.Persistence.Repositories;

using BookStore.Domain.Books;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

internal class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<BookRepository> logger;

    public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<(IEnumerable<Book> Entries, int Count, int TotalCount)> GetBooksAsync(
        string? titleSearch = null,
        DateTime? releaseDateSearch = null)
    {
        this.logger.LogDebug($"Retrieving list of {nameof(Book)} items");

        var query = this.context.Books.AsQueryable();
        var totalCount = await this.context.Books.CountAsync();

        if (titleSearch != null)
        {
            query = query.Where(a => a.Title.Contains(titleSearch));
        }

        if (releaseDateSearch != null)
        {
            query = query.Where(a => a.ReleaseDate == releaseDateSearch);
        }

        var count = await query.CountAsync();

        IEnumerable<Book> entries = await query.ToListAsync();
        return (entries, count, totalCount);
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        this.logger.LogDebug($"Retrieving {nameof(Book)} with id {{Id}}", id);

        return await this.context.Books.FindAsync(id);
    }
}
