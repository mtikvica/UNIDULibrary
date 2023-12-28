using System.Linq.Expressions;

namespace Library.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    IQueryable<T> GetAllWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteAsync<U>(U id);
}