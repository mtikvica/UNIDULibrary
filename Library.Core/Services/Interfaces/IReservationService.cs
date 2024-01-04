using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services;
public interface IReservationService
{
    Task<ReservationDto> AddReservationAsync(Guid studentID, Guid bookId);
    Task CancelReservation(Guid reservationId);
    Task<Reservation> GetReservation(Guid reservationId);
    Task<IEnumerable<Reservation>> GetReservationByCopyId(Guid copyId);
    Task<IEnumerable<Reservation>> GetReservationsForStudent(Guid studentId);
    Task<IEnumerable<Reservation>> GetUnprocessedReservationsAsync();
    Task UpdateReservationAsync(Reservation reservation);
}