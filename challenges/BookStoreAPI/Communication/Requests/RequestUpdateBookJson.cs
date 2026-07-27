using BookStoreAPI.Entities;

namespace BookStoreAPI.Communication.Requests;

public class RequestUpdateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
