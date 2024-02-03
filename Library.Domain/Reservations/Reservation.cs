using Library.Domain.Abstractions;
using Library.Domain.Reservations.Events;

namespace Library.Domain.Reservations;

public sealed class Reservation : Entity
{
    private Reservation(Guid studentId, Guid bookCopyId, DateTime date)
    {
        StudentId = studentId;
        BookCopyId = bookCopyId;
        DateRange = ReservationDateRange.Create(date);
    }

    public Guid StudentId { get; }
    public Guid BookCopyId { get; }
    public ReservationDateRange DateRange { get; }
    public bool IsProcessed { get; private set; }

    public static Reservation Create(Guid studentId, Guid bookCopyId, DateTime date)
    {
        var reservation = new Reservation(studentId, bookCopyId, date);

        reservation.RaiseDomainEvent(new ReservationCreatedDomainEvent(bookCopyId));

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
