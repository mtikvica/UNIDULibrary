namespace Library.Domain.Reservations;
public interface IReservationRepository
{
    Task<Reservation?> GetActiveReservationOnBookAsync(Guid studentId, Guid bookId);
}
