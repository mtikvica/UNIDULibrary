namespace Library.Domain.Books;
public interface IBookRepository
{
    Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
