using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Messaging;
using Library.Application.Shared.Fines;
using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Fines;
using Library.Domain.Loans;

namespace Library.Application.Loans.CreateLoan;
internal sealed class CreateLoanCommandHandler(
    ILoanRepository loanRepository,
    IBookCopyRepository bookCopyRepository,
    IFineService fineService,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : ICommandHandler<CreateLoanCommand, Guid>
{
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IFineService _fineService = fineService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public async Task<Result<Guid>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var fines = await _fineService.GetUnpaidFinesByStundet(request.StudentId);

        if (fines is not null)
        {
            return Result.Failure<Guid>(FineErrors.AlreadyFined);
        }

        var bookCopy = await _bookCopyRepository.GetAvailableBookCopyForLoanAsync(request.BookId, cancellationToken);

        if (bookCopy is null)
        {
            return Result.Failure<Guid>(BookCopyErrors.NotAvailableForLoan);
        }

        var loan = Loan.Create(request.StudentId, bookCopy.Id, _dateTimeProvider.UtcNow);

        _loanRepository.Add(loan);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return loan.Id;
    }
}
