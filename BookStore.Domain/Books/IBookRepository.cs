namespace BookStore.Domain.Books;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain.Entities;

public interface IBookRepository
{
    Task<(IEnumerable<Book> Entries, int Count, int TotalCount)> GetBooksAsync(
        string? titleSearch = null,
        DateTime? releaseDateSearch = null);

    Task<Book?> GetBookAsync(int id);
}
