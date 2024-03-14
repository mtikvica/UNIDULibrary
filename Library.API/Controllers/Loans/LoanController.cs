using Library.Application.Loans.CreateLoan;
using Library.Application.Loans.CreateLoanReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Loans;
[Route("loans")]
[ApiController]
public class LoanController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> LoanBook(Guid bookId, Guid studentId, CancellationToken cancellationToken)
    {
        var command = new CreateLoanCommand(bookId, studentId);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(LoanBook), result.IsSuccess ? result.Value : result.Error);
    }

    [HttpPost("reservation/{id}")]
    public async Task<IActionResult> LoanBookWithReservation(Guid id, CancellationToken cancellationToken)
    {
        var command = new CreateLoanWithReservationCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(LoanBookWithReservation), result.IsSuccess ? result.Value : result.Error);
    }
}