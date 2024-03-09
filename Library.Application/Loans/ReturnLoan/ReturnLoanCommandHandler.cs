using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.Fines;
using Library.Domain.Loans;

namespace Library.Application.Loans.ReturnLoan;
internal class ReturnLoanCommandHandler(ILoanRepository loanRepository,
    IUnitOfWork unitOfWork,
    IFineRepository fineRepository,
    IDateTimeProvider dateTimeProvider) : ICommandHandler<ReturnLoanCommand>
{
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IFineRepository _fineRepository = fineRepository;

    public async Task<Result> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId, cancellationToken);

        if (loan is null)
        {
            return Result.Failure(LoanErrors.NotReturned);
        }

        var todayDate = DateOnly.FromDateTime(_dateTimeProvider.UtcNow.Date);

        loan.Return(todayDate);

        var overdueDays = loan.CalculateOverdueDays(todayDate);

        if (overdueDays > 0)
        {
            var fine = Fine.Create(loan.StudentId, overdueDays, true, _dateTimeProvider.UtcNow);

            _fineRepository.Add(fine);
        }

        _loanRepository.Update(loan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
