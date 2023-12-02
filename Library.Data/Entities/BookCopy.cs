using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities;

public class BookCopy
{
    [Key]
    public Guid CopyId { get; set; } = new Guid();
    public Guid BookId { get; set; }
    public required Book Book { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}