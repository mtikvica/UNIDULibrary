using Library.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;
public abstract class Repository<T> where T : Entity
{
    protected readonly LibraryDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;
    protected Repository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();

    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
