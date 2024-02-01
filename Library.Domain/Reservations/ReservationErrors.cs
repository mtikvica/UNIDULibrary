using Library.Domain.Abstractions;

namespace Library.Domain.Reservations;
public static class ReservationErrors
{
    public static Error Expired = new(
        "Reservation.Expired",
        "Reservation is expired!"
        );
}
