namespace BookStore.Domain.Entities;

public class Book
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public required List<Order> Orders { get; set; }
}
