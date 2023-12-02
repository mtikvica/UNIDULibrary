namespace Library.Data.Entities;

public class Publisher
{
    public int PublisherId { get; set; }
    public string PublisherName { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
