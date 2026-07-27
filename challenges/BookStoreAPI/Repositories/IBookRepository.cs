using BookStoreAPI.Entities;

namespace BookStoreAPI.Repositories;

public interface IBookRepository
{
    void Add(Book book);
    List<Book> GetAll();
    Book? GetById(int id);
    void Update(Book book);
    void Delete(int id);
}
