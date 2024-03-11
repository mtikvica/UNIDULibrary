using Library.Domain.Authors;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class AuthorRepository(LibraryDbContext dbContext) : Repository<Author>(dbContext), IAuthorRepository
{
    public void Add(IEnumerable<Author> authors)
    {
        _dbContext.Add(authors);
    }

    public Task<Author?> GetByOpenLibraryCode(string openLibraryAuthorCode, CancellationToken cancellationToken = default)
    {
        return _dbSet
            .FirstOrDefaultAsync(x => x.OpenLibraryAuthorCode == openLibraryAuthorCode,
            cancellationToken: cancellationToken);
    }
}
