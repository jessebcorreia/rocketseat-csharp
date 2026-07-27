using BookStoreAPI.Communication.Requests;
using BookStoreAPI.Communication.Responses;
using BookStoreAPI.Entities;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;

public class BookController : BookStoreControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseGetBookJson>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        List<Book> books = _bookRepository.GetAll();

        List<ResponseGetBookJson> response = books.Select(book => new ResponseGetBookJson
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            StockQuantity = book.StockQuantity
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        Book? book = _bookRepository.GetById(id);

        if (book is null)
            return NotFound($"The book with id: {id} was not found.");

        ResponseGetBookJson response = new()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            StockQuantity = book.StockQuantity
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseGetBookJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestCreateBookJson request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            StockQuantity = request.StockQuantity
        };

        _bookRepository.Add(book);

        var response = new ResponseGetBookJson
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            StockQuantity = book.StockQuantity
        };

        return CreatedAtAction(
            nameof(GetById),
            new { id = book.Id },
            response
        );
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(
        [FromRoute] int id,
        [FromBody] RequestUpdateBookJson request)
    {
        Book? existingBook = _bookRepository.GetById(id);

        if (existingBook is null)
            return NotFound($"The book with id: {id} was not found.");

        Book book = new()
        {
            Id = id,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            StockQuantity = request.StockQuantity
        };

        _bookRepository.Update(book);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        Book? book = _bookRepository.GetById(id);

        if (book is null)
            return NotFound($"The book with id: {id} was not found.");

        _bookRepository.Delete(id);

        return NoContent();
    }
}
