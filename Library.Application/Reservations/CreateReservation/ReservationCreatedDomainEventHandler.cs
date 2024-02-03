using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Reservations.Events;
using MediatR;

namespace Library.Application.Reservations.CreateReservation;
internal sealed class ReservationCreatedDomainEventHandler(
    IBookCopyRepository bookCopyRepository,
    IUnitOfWork unitOfWork)
    : INotificationHandler<ReservationCreatedDomainEvent>
{
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(ReservationCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var bookCopy = await _bookCopyRepository.GetByIdAsync(notification.BookCopyId);

        bookCopy.ProcessReservation();

        _bookCopyRepository.Update(bookCopy);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
