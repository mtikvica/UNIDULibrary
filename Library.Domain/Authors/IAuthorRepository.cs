namespace Library.Domain.Authors;
public interface IAuthorRepository
{
    Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default);

    void Add(Author author);
    void Update(Author author);
    void Delete(Author author);
}
