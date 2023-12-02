namespace Library.Data.Entities;

public class Subject
{
    public int SubjectId { get; set; }
    public required string Name { get; set; }
    public required ICollection<Book> Books { get; set; }
}