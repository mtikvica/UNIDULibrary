using Library.Domain.Abstractions;

namespace Library.Domain.Publishers;

public sealed class Publisher : Entity
{
    private Publisher(string publisherName)
    {
        PublisherName = publisherName;
    }

    private Publisher() { }

    public string PublisherName { get; } = null!;

    public static Publisher Create(string publisherName)
    {
        return new Publisher(publisherName);
    }
}
