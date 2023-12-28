namespace Library.Data.Entities;

public class Book
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int? NumberOfPages { get; set; }

    public int? DepartmentId { get; set; }

    public int? PublisherId { get; set; }

    public int? LocationId { get; set; }

    public int? PublicationYear { get; set; }

    public InventoryState? InventoryState { get; set; }

    public Department? Department { get; set; }

    public Location? Location { get; set; }

    public Publisher? Publisher { get; set; }

    public IEnumerable<Author> Authors { get; set; } = new List<Author>();

    public IEnumerable<Subject> Subjects { get; set; } = new List<Subject>();
}