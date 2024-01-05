using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("reservations")]
[ApiController]
public class ReservationController(IReservationService reservationService) : ControllerBase
{
    private readonly IReservationService _reservationService = reservationService;

    [HttpPost]
    public async Task<IActionResult> AddReservation(Guid studentId, Guid bookId)
    {
        var reservation = await _reservationService.AddReservationAsync(studentId, bookId);
        return Created($"Added reservation for student: {studentId}", reservation);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> CancelReservation(Guid id)
    {
        await _reservationService.CancelReservation(id);
        return NoContent();
    }
}
