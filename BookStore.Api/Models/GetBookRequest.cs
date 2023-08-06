namespace BookStore.Api.Models;
public class GetBookRequest
{
    public string? TitleSearch { get; set; }
    public DateTime? ReleaseDateSearch { get; set; }
}