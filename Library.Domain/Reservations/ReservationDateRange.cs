namespace Library.Domain.Reservations;
public record ReservationDateRange
{
    private ReservationDateRange(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    private static readonly int _reservationExpiryDays = 3;

    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }

    public static ReservationDateRange Create(DateTime startDate)
    {

        var dayOfWeek = DateTime.Now.DayOfWeek;

        if (dayOfWeek == DayOfWeek.Saturday)
        {
            return new ReservationDateRange(startDate, startDate.AddDays(_reservationExpiryDays + 2));
        }
        else if (dayOfWeek == DayOfWeek.Sunday)
        {
            return new ReservationDateRange(startDate, startDate.AddDays(_reservationExpiryDays + 1));
        }

        return new ReservationDateRange(startDate, startDate.AddDays(_reservationExpiryDays));
    }

}
