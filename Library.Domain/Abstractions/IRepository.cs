namespace Library.Domain.Abstractions;
public interface IRepository
{
    Task<T> GetByIdAsyncAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : class;
    Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class;
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
}
