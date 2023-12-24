using Library.Data.Context;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Data.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly UNIDULibraryDbContext _context;
    private readonly DbSet<T> _entity;

    public Repository(UNIDULibraryDbContext context)
    {
        _context = context;
        _entity = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entity.AsNoTracking().ToListAsync();
    }

    public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
    {
        return _entity.AsNoTracking().Where(predicate);
    }
    public async Task<T> AddAsync(T entity)
    {
        _entity.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync<U>(U id)
    {
        var entity = await _entity.FindAsync(id) ?? throw new NotFoundException($"Entity with id: {id} was not found!");

        await DeleteAsync(entity);
    }
}
