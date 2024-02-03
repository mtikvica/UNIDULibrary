using Library.Domain.Abstractions;

namespace Library.Domain.Reservations;
public static class ReservationErrors
{
    public static Error Expired = new(
        "Reservation.Expired",
        "Reservation is expired!"
        );

    public static Error AlreadyReserved = new(
        "Reservation.AlreadyReserved",
        "Book is already reserved!");

    public static Error NotFound = new(
        "Reservation.NotFound",
        "Reservation not found!"
        );
}
