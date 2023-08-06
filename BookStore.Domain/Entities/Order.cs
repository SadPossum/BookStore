namespace BookStore.Domain.Entities;

public class Order
{
    public required int Id { get; set; }
    public required string OrderNumber { get; set; }
    public required DateTime OrderDate { get; set; }
    public required List<Book> Books { get; set; }
}
