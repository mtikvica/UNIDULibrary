namespace Library.Core.Dtos;
public class BookDto(string title, string isbn)
{
    public string Title { get; set; } = title;

    public string Isbn { get; set; } = isbn;

    public int? NumberOfPages { get; set; }

    public int? DepartmentId { get; set; }

    public int? PublisherId { get; set; }

    public int? LocationId { get; set; }

    public DateOnly? PublicationDate { get; set; }
}
