using Library.Application.Books.CreateBookWithOpenLibrary;
using Library.Application.Books.GetBookQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Book;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var query = new GetBookQuery(id);
        var book = await _mediator.Send(query);

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookCommand command)
    {
        var bookId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetBook), new { id = bookId }, bookId);
    }

}
