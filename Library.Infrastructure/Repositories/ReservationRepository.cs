using Library.Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class ReservationRepository(LibraryDbContext dbContext) : Repository<Reservation>(dbContext), IReservationRepository
{
    public Task<Reservation?> GetActiveReservationOnBookAsync(Guid studentId, Guid bookId)
    {
        return _dbSet.Include(reservation => reservation.DateRange)
            .Where(reservation => reservation.StudentId == studentId)
            .Where(reservation => reservation.BookCopyId == bookId)
            .Where(reservation => !reservation.IsProcessed)
            .SingleOrDefaultAsync();
    }
}
