namespace Library.Domain.Books;
public interface IBookRepository
{
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Book?> GetByIsbn(string isbn, CancellationToken cancellationToken = default);
    void Add(Book book);
    void Update(Book book);
    void Delete(Book book);
}
