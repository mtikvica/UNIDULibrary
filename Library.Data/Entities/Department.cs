using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public IEnumerable<Book> Books { get; set; } = new List<Book>();

    public IEnumerable<Student> Students { get; set; } = new List<Student>();
}