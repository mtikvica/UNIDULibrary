namespace Library.Core.Dtos;
public class BookDto
{
    public BookDto(string title, string isbn)
    {
        Title = title;
        Isbn = isbn;
    }


    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int? NumberOfPages { get; set; }

    public int? DepartmentId { get; set; }

    public int? PublisherId { get; set; }

    public int? LocationId { get; set; }

    public DateOnly? PublicationDate { get; set; }
}
