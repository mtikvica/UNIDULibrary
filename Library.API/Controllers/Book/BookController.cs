using Library.Application.Books.CreateBookWithOpenLibrary;
using Library.Application.Books.GetBookQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Book;
[Route("api/[controller]")]
[ApiController]
public class BookController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

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
        var bookId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetBook), new { id = bookId }, bookId);
    }

}
