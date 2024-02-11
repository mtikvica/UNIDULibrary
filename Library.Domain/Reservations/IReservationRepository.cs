
namespace Library.Domain.Reservations;
public interface IReservationRepository
{
    void Add(Reservation reservation);
    Task<Reservation?> GetActiveReservationOnBookAsync(Guid studentId, Guid bookId);
    Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
