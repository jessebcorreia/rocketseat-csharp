namespace BookStoreAPI.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public Book(int id, string title, Genre genre, decimal price, int stockQuantity)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public Book(string title, Genre genre, decimal price, int stockQuantity)
    {
        Title = title;
        Genre = genre;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public Book() { }
}
