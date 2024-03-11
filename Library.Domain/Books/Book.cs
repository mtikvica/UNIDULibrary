using Library.Domain.Abstractions;

namespace Library.Domain.Books;

public sealed class Book : Entity
{
    private Book(string title, string isbn, int? publicationYear, int? numberOfPages, Guid publisherId)
    {
        Title = title;
        Isbn = isbn;
        PublicationYear = publicationYear;
        NumberOfPages = numberOfPages;
        PublisherId = publisherId;
    }

    private Book() { }

    public string Title { get; }

    public string Isbn { get; }

    public int? NumberOfPages { get; private set; }

    public Guid? DepartmentId { get; private set; }

    public Guid? PublisherId { get; private set; }

    public Guid? LocationId { get; private set; }

    public int? PublicationYear { get; private set; }

    public static Book CreateFromOpenLibrary(string title, string isbn, string? publishDate, int? numberOfPages, Guid publisherId)
    {
        return new Book(title,
                            isbn,
                            int.TryParse(publishDate, out var publicationYear) ? publicationYear : null,
                            numberOfPages, publisherId);
    }

    public Book UpdateWithMissingProperties(int numberOfPages, Guid departmentId, Guid publisherId, Guid locationId)
    {
        NumberOfPages = numberOfPages;
        DepartmentId = departmentId;
        PublisherId = publisherId;
        LocationId = locationId;

        return this;
    }
}