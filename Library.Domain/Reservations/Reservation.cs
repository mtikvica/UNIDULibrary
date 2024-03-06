using Library.Domain.Abstractions;

namespace Library.Domain.Reservations;

public sealed class Reservation : Entity
{
    private Reservation(Guid studentId, Guid bookCopyId, DateTime date)
    {
        StudentId = studentId;
        BookCopyId = bookCopyId;
        DateRange = ReservationDateRange.Create(date);
    }

    private Reservation() { }

    public Guid StudentId { get; }
    public Guid BookCopyId { get; }
    public ReservationDateRange DateRange { get; }
    public bool IsProcessed { get; private set; }

    public static Reservation Create(Guid studentId, Guid bookCopyId, DateTime date)
    {
        return new Reservation(studentId, bookCopyId, date);
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
