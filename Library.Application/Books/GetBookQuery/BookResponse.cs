using Library.Domain.Authors;
using Library.Domain.Books;

namespace Library.Application.Books.GetBookQuery;

public sealed class BookResponse
{
    private BookResponse(Guid id, string title, string author, int pages, string publisher, int publicationYear, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        Pages = pages;
        Publisher = publisher;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public Guid Id { get; init; }
    public string Title { get; init; }
    public IEnumerable<Author> Author { get; init; }
    public int Pages { get; init; }
    public string Publisher { get; init; }
    public int PublicationYear { get; init; }
    public string ISBN { get; init; }

    public static BookResponse Create(Book book)
    {
        return new BookResponse(book.Id,
            book.Title,
            author,
            book.Pages,
            book.Publisher,
            book.PublicationYear,
            book.Isbn);
    }
}