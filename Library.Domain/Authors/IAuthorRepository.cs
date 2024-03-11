namespace Library.Domain.Authors;
public interface IAuthorRepository
{
    Task<Author?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Author?> GetByOpenLibraryCode(string openLibraryAuthorCode, CancellationToken cancellationToken = default);

    void Add(Author author);
    void Add(IEnumerable<Author> authors);
    void Update(Author author);
    void Delete(Author author);
}
