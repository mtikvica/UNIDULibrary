using Library.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("loans")]
[ApiController]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoansForStudent(Guid studentId)
    {
        var loans = await _loanService.GetLoansByStudentId(studentId);

        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> AddLoan(Guid bookId, Guid studentId)
    {
        await _loanService.AddLoan(bookId, studentId);

        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> ReturnLoan(Guid loanId)
    {
        await _loanService.ReturnLoan(loanId);

        return Ok();
    }

    [HttpPost("reservation/{id}")]
    public async Task<IActionResult> AddLoanOnReservation(Guid id)
    {
        await _loanService.AddLoanOnReservationAsync(id);

        return Ok();
    }
}