using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class LoanService(ILoanRepository loanRepository, IReservationRepository reservationRepository, IBookCopyRepository bookCopyRepository, IFineService fineService, IMapper mapper) : ILoanService
{
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IFineService _fineService = fineService;
    private readonly IMapper _mapper = mapper;

    public async Task AddLoan(Guid bookId, Guid studentId)
    {
        var fines = await _fineService.GetUnpaidFinesForStudent(studentId);

        if (fines.Any())
        {
            throw new Exception($"Student with id : {studentId} has fines!");
        }

        var bookCopy = await _bookCopyRepository.GetBy(x => x.BookId == bookId && x.IsAvailable == true && x.IsReserved == false).FirstOrDefaultAsync() ?? throw new Exception($"There are no available book copies!");
        bookCopy.ProcessLoan();

        var loan = new LoanDto(bookCopy.CopyId, studentId);

        await _loanRepository.AddAsync(_mapper.Map<Loan>(loan));
        await _bookCopyRepository.UpdateAsync(bookCopy);
    }

    public async Task ReturnLoan(Guid loanId)
    {
        var loan = await _loanRepository.GetBy(x => x.LoanId == loanId).FirstOrDefaultAsync() ?? throw new Exception($"Loan with id : {loanId} was not found!");

        loan.ReturnLoan();

        var daysOverdue = loan.GetDaysOverdue();

        if (daysOverdue > 0)
        {
            await _fineService.AddFineAsync(loan.StudentId, daysOverdue);
        }

        var bookCopy = await _bookCopyRepository.GetBy(x => x.CopyId == loan.CopyId).FirstOrDefaultAsync() ?? throw new Exception($"Book copy with id : {loan.CopyId} was not found!");
        bookCopy.ProcessLoan();

        await _loanRepository.UpdateAsync(loan);
        await _bookCopyRepository.UpdateAsync(bookCopy);
    }

    public async Task AddLoanOnReservationAsync(Guid reservationId)
    {
        var reservation = await _reservationRepository.GetBy(x => x.ReservationId == reservationId).FirstOrDefaultAsync() ?? throw new Exception($"Reservation with id : {reservationId} was not found!");

        reservation.ProcessReservation();

        var loan = new LoanDto(reservation.BookCopyId, reservation.StudentId);

        await _reservationRepository.UpdateAsync(reservation);
        await _loanRepository.AddAsync(_mapper.Map<Loan>(loan));
    }

    public async Task<IEnumerable<Loan>> GetLoansByStudentId(Guid studentId)
    {
        var loans = await _loanRepository.GetBy(x => x.StudentId == studentId).ToListAsync();

        return loans;
    }
}
