using Library.Application.BookCopies.CreateBookCopy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.BookCopies;
[Route("bookcopies")]
[ApiController]
public class BookCopyController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateBookCopies(Guid bookId, int ammount)
    {
        var command = new CreateBookCopyCommand(bookId, ammount);

        await _mediator.Send(command);

        return Created();
    }
}
