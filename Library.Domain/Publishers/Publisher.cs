using Library.Domain.Abstractions;
using Library.Domain.Books;

namespace Library.Domain.Publishers;

public sealed class Publisher : Entity
{
    private Publisher(string publisherName)
    {
        PublisherName = publisherName;
    }
    public string PublisherName { get; } = null!;
    public ICollection<Book> Books { get; } = new List<Book>();

    public static Publisher Create(string publisherName)
    {
        return new Publisher(publisherName);
    }
}
