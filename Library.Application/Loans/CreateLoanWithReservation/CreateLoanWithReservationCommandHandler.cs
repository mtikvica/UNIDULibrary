using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.Loans;
using Library.Domain.Reservations;

namespace Library.Application.Loans.CreateLoanReservation;
internal sealed class CreateLoanWithReservationCommandHandler(
    IReservationRepository reservationRepository,
    ILoanRepository loanRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider)
    : ICommandHandler<CreateLoanWithReservationCommand, Guid>
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public async Task<Result<Guid>> Handle(CreateLoanWithReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId, cancellationToken);

        if (reservation is null)
        {
            return Result.Failure<Guid>(ReservationErrors.NotFound);
        }

        var loan = Loan.Create(reservation.StudentId, reservation.BookCopyId, _dateTimeProvider.UtcNow);

        _loanRepository.Add(loan);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return loan.Id;
    }
}
