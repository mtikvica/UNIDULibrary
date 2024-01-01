namespace Library.Core.Responses.BookResponse;
public class BookResponse
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int? NumberOfPages { get; set; }

    public int? PublicationYear { get; set; }

    public string? PublisherName { get; set; }

    public string? LocationName { get; set; }

    public string? DepartmentName { get; set; }

    public List<AuthorResponse>? Authors { get; set; }
}
