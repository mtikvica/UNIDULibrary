using Library.Domain.Publishers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
internal class PublisherRepository(LibraryDbContext dbContext) : Repository<Publisher>(dbContext), IPublisherRepository
{
    public async Task<Publisher?> GetPublisherByName(string name, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.PublisherName.Equals(name), cancellationToken: cancellationToken);
    }
}
