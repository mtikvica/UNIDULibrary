using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Fines;
using Library.Domain.Reservations;

namespace Library.Application.Reservations.CreateReservation;
internal class CreateReservationCommandHandler(IReservationRepository reservationRepository,
    IFineRepository fineRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider,
    IBookCopyRepository bookCopyRepository) : ICommandHandler<CreateReservationCommand, Guid>
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IFineRepository _fineRepository = fineRepository;
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public async Task<Result<Guid>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var fines = await _fineRepository.GetUnpaidFinesByStundet(request.StudentId);

        if (fines.Any())
        {
            return Result.Failure<Guid>(FineErrors.AlreadyFined);
        }

        var studentAlreadyHasReservationOnABook = await _reservationRepository.GetActiveReservationOnBookAsync(request.StudentId, request.BookId);

        if (studentAlreadyHasReservationOnABook is not null)
        {
            return Result.Failure<Guid>(ReservationErrors.AlreadyReserved);
        }

        var bookCopy = await _bookCopyRepository.GetAvailableBookCopyForReservationAsync(request.BookId, cancellationToken);

        if (bookCopy is null)
        {
            return Result.Failure<Guid>(ReservationErrors.NoAvailableCopies);
        }

        var reservation = Reservation.Create(request.StudentId, bookCopy.Id, _dateTimeProvider.UtcNow);

        _reservationRepository.Add(reservation);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }
}
