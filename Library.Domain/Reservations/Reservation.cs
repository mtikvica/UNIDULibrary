using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Reservations.Events;

namespace Library.Domain.Reservations;

public sealed class Reservation : Entity
{
    private Reservation(Guid studentId, Guid bookCopyId)
    {
        StudentId = studentId;
        BookCopyId = bookCopyId;
    }

    public Guid StudentId { get; }
    public Guid BookCopyId { get; }
    public ReservationDateRange DateRange { get; } = ReservationDateRange.Create(DateTime.Now);
    public bool IsProcessed { get; private set; }

    public static Reservation Create(Guid studentId, BookCopy bookCopy)
    {
        var reservation = new Reservation(studentId, bookCopy.Id);

        reservation.RaiseDomainEvent(new ReservationCreatedDomainEvent(reservation.Id));

        bookCopy.ProcessReservation();

        return reservation;
    }

    public Result Expired()
    {
        if (DateRange.EndDate < DateTime.Now)
        {
            return Result.Success();
        }

        return Result.Failure(ReservationErrors.Expired);
    }

    public void ProcessReservation()
    {
        IsProcessed = true;
    }
}
