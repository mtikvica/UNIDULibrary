using Library.Domain.Abstractions;
using Library.Domain.Books;

namespace Library.Domain.Authors;

public sealed class Author(string authorName, string? authorOpenLibraryKey) : Entity
{
    public string? AuthorOpenLibraryKey { get; } = authorOpenLibraryKey;

    public string AuthorName { get; } = authorName;

    public IEnumerable<Book> Books { get; } = new List<Book>();
}