using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;

public interface ILoanService
{
    Task AddLoan(Guid bookId, Guid studentId);
    Task AddLoanOnReservationAsync(Guid reservationId);
    Task ReturnLoan(Guid loanId);
    Task<IEnumerable<Loan>> GetLoansByStudentId(Guid studentId);
}