using Library.Domain.Abstractions;

namespace Library.Domain.Reservations;
public interface IReservationRepository : IRepository
{
    Task<Reservation> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Reservation> GetActiveReservationOnBookAsync(Guid studentId, Guid bookId);
    void Add(Reservation reservation);
    void Update(Reservation reservation);
    void Delete(Reservation reservation);
}
