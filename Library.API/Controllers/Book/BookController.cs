using Library.Application.Books.CreateBookWithOpenLibrary;
using Library.Application.Books.GetBookQuery;
using Library.Application.Books.GetBooksQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Book;
[Route("api/[controller]")]
[ApiController]
public class BookController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] int page = 1, [FromQuery] int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var query = new GetBooksQuery(page, pageSize);
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBookQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Name);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateBook), result.IsSuccess ? result.Value : result.Error);
    }
}
