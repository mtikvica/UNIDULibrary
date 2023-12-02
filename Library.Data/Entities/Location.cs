namespace Library.Data.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string LocationName { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}