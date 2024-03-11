using Library.Domain.Abstractions;

namespace Library.Domain.Publishers;
public static class PublisherErrors
{
    public static Error OpenLibraryNotFound = new(
        "Publisher.NotFound",
        "OpenLibrary hasn't assigned publisher!"
        );
}
