namespace Library.Data.Entities;

public class Author
{
    public Guid AuthorId { get; set; }

    public string? AuthorOpenLibraryKey { get; set; }

    public string AuthorName { get; set; } = null!;

    public IEnumerable<Book> Books { get; set; } = new List<Book>();
}