using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class BookRepository(LibraryDbContext dbContext) : Repository<Book>(dbContext), IBookRepository
{
    public Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.Isbn == isbn, cancellationToken);
    }
}
