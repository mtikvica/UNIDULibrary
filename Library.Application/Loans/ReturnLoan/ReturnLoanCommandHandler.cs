using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Fines;
using Library.Domain.Loans;

namespace Library.Application.Loans.ReturnLoan;
internal class ReturnLoanCommandHandler(ILoanRepository loanRepository,
    IUnitOfWork unitOfWork,
    IFineRepository fineRepository,
    IDateTimeProvider dateTimeProvider,
    IBookCopyRepository bookCopyRepository) : ICommandHandler<ReturnLoanCommand, string>
{
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IFineRepository _fineRepository = fineRepository;
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;

    public async Task<Result<string>> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId, cancellationToken);
        Fine? fine = null;

        if (loan is null)
        {
            return Result.Failure<string>(LoanErrors.NotReturned);
        }

        var todayDate = DateOnly.FromDateTime(_dateTimeProvider.UtcNow.Date);

        loan.Return(todayDate.AddDays(50));

        var overdueDays = loan.CalculateOverdueDays();

        if (overdueDays > 0)
        {
            fine = Fine.Create(loan.Id, overdueDays, false, _dateTimeProvider.UtcNow);

            _fineRepository.Add(fine);
        }

        var bookCopy = await _bookCopyRepository.GetByIdAsync(loan.BookCopyId, cancellationToken);

        if (bookCopy is null)
        {
            return Result.Failure<string>(BookCopyErrors.NotFound);
        }

        bookCopy.ProcessLoan();

        _loanRepository.Update(loan);
        _bookCopyRepository.Update(bookCopy);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var message = fine is null ?
            "Book returned successfully without any fines." : $"Book returned with the fine: {fine.Amount} €.";

        return Result.Success(message);
    }
}
