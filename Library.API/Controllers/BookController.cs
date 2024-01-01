using Library.Core.Requests;
using Library.Core.Services;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] PageRequest request)
    {
        var books = await _bookService.GetAllBooks(request);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var book = await _bookService.GetBookAsync(id);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBookWithDetails(string isbn)
    {
        await _bookService.AddBookWithDetailsByIsbnAsync(isbn);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var response = await _bookService.UpdateBookAsync(book);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }

    [HttpGet("author/{author}")]
    public async Task<IActionResult> GetBookByAuthor(string author)
    {
        var book = await _bookService.GetBookByAuthorAsync(author);
        return Ok(book);
    }

    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetBookByTitle(string title)
    {
        var book = await _bookService.GetBookByTitleAsync(title);
        return Ok(book);
    }
}
