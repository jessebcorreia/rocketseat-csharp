using BookStoreAPI.Entities;

namespace BookStoreAPI.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public void Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
    }

    public void Delete(int id)
    {
        var book = GetById(id);

        if (book is not null)
        {
            _books.Remove(book);
        }
    }

    public List<Book> GetAll()
    {
        return _books;
    }

    public Book? GetById(int id)
    {
        return _books.FirstOrDefault(book => book.Id == id);
    }

    public void Update(Book book)
    {
        var existingBook = GetById(book.Id);

        if (existingBook is null)
        {
            return;
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Genre = book.Genre;
        existingBook.Price = book.Price;
        existingBook.StockQuantity = book.StockQuantity;
    }
}
