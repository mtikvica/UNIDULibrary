using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("book_copies")]
[ApiController]
public class BookCopyController : ControllerBase
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopyController(IBookCopyService bookCopyService)
    {
        _bookCopyService = bookCopyService;
    }

    [HttpGet("bookId/{bookId}")]
    public async Task<IActionResult> GetBookCopies(Guid bookId)
    {
        var bookCopies = await _bookCopyService.GetBookCopiesAsync(bookId);
        return Ok(bookCopies);
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<IActionResult> GetBookCopies(string isbn)
    {
        var bookCopies = await _bookCopyService.GetBookCopiesAsync(isbn);
        return Ok(bookCopies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookCopy(Guid id)
    {
        var bookCopy = await _bookCopyService.GetBookCopyByIdAsync(id);
        return Ok(bookCopy);
    }

    [HttpPost("bookId/{bookId}")]
    public async Task<IActionResult> AddBookCopy(Guid bookId, int ammount)
    {
        await _bookCopyService.AddBookCopyAsync(bookId, ammount);
        return Created();
    }

    [HttpPost("isbn/{isbn}")]
    public async Task<IActionResult> AddBookCopy(string isbn, int ammount = 1)
    {
        await _bookCopyService.AddBookCopyAsync(isbn, ammount);
        return Created();
    }

}
