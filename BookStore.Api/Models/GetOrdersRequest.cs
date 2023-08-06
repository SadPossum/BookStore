namespace BookStore.Api.Models;
public class GetOrdersRequest
{
    public string? OrderNumberSearch { get; set; }
    public DateTime? OrderDateSearch { get; set; }
}