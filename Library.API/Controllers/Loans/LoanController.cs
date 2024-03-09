using Library.Application.Loans.CreateLoan;
using Library.Application.Loans.CreateLoanReservation;
using Library.Application.Loans.ReturnLoan;
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

        return result.IsFailure ? BadRequest(result.Error.Name) : CreatedAtAction(nameof(LoanBook), new { id = result.Value }, result);
    }

    [HttpPost("reservation/{id}")]
    public async Task<IActionResult> LoanBookWithReservation(Guid id, CancellationToken cancellationToken)
    {
        var command = new CreateLoanWithReservationCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(LoanBookWithReservation), new { id = result.Value }, result);
    }

    [HttpPut("return/{id}")]
    public async Task<IActionResult> ReturnBook(Guid id, CancellationToken cancellationToken)
    {
        var command = new ReturnLoanCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return result.IsFailure ? BadRequest(result.Error.Name) : NoContent();
    }
}