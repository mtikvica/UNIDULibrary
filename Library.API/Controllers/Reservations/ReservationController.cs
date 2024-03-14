using Library.Application.Reservations.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Reservations;
[Route("reservations")]
[ApiController]
public class ReservationController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("{studentId}/books/{bookId}")]
    public async Task<IActionResult> ReserveBook(Guid studentId, Guid bookId, CancellationToken cancellationToken)
    {
        var command = new CreateReservationCommand(studentId, bookId);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(ReserveBook), result.IsSuccess ? result.Value : result.Error);
    }
}
