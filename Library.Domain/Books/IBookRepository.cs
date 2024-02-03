using Library.Domain.Abstractions;

namespace Library.Domain.Books;
public interface IBookRepository : IRepository
{
    Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
