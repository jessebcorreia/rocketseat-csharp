using BookStoreAPI.Entities;

namespace BookStoreAPI.Communication.Responses;

public class ResponseGetBookJson
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public Genre Genre { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
}
