using Library.Application.BookCopies.CreateBookCopy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.BookCopies;
[Route("api/[controller]")]
[ApiController]
public class BookCopyController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateBookCopies([FromBody] CreateBookCopyRequest request)
    {
        var command = new CreateBookCopyCommand(request.BookId, request.Ammount);

        await _mediator.Send(command);

        return Created();
    }
}
