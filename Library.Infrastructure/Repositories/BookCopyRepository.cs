using Library.Domain.BookCopies;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class BookCopyRepository(LibraryDbContext dbContext) : Repository<BookCopy>(dbContext), IBookCopyRepository
{
    public async Task<BookCopy?> GetAvailableBookCopyForLoanAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(bc => bc.BookId == bookId && bc.IsAvailable && !bc.IsReserved, cancellationToken);
    }

    public async Task<BookCopy?> GetAvailableBookCopyForReservationAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FirstOrDefaultAsync(bc => bc.BookId == bookId && !bc.IsReserved, cancellationToken);
    }
}
