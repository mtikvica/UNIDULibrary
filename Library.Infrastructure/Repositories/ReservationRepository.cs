using Library.Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class ReservationRepository(LibraryDbContext dbContext) : Repository<Reservation>(dbContext), IReservationRepository
{
    public Task<Reservation?> GetActiveReservationOnBookAsync(Guid studentId, Guid bookId)
    {
        return _dbSet
            .Where(reservation => reservation.DateRange.StartDate <= DateTime.Now)
            .Where(reservation => reservation.DateRange.EndDate >= DateTime.Now)
            .Where(reservation => reservation.StudentId == studentId)
            .Where(reservation => reservation.BookCopyId == bookId)
            .Where(reservation => !reservation.IsProcessed)
            .SingleOrDefaultAsync();
    }
}
