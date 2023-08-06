namespace BookStore.Domain.Books;
using System;

public class BookDto
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public DateTime? ReleaseDate { get; private set; }

    public BookDto(int id, string title, DateTime? releaseDate)
    {
        this.Id = id;
        this.Title = title;
        this.ReleaseDate = releaseDate;
    }
}
