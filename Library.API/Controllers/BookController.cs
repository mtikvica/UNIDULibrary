using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{
    private readonly IBookService _bookService = bookService;

    //[HttpGet]
    //public async Task<IActionResult> GetBooks()
    //{
    //    var books = await _bookService.GetBooksAsync();
    //    return Ok(books);
    //}

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetBook(int id)
    //{
    //    var book = await _bookService.GetBookAsync(id);
    //    return Ok(book);
    //}

    [HttpPost]
    public async Task<IActionResult> AddBook(string isbn)
    {
        await _bookService.AddBookWithDetailsByIsbnAsync(isbn);
        return Created();
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateBook(Book book)
    //{
    //    var response = await _bookService.UpdateBookAsync(book);
    //    return Ok(response);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteBook(int id)
    //{
    //    await _bookService.DeleteBookAsync(id);
    //    return NoContent();
}
