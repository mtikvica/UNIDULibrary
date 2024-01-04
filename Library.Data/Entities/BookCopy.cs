using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities;

public class BookCopy
{
    [Key]
    public Guid CopyId { get; set; } = new Guid();
    public Guid BookId { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsReserved { get; set; }
    public required Book Book { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public void ProcessReservation()
    {
        if (IsReserved)
        {
            IsReserved = false;
        }
        IsReserved = true;
    }

    public void ProcessLoan()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
        }
        IsAvailable = true;
    }
}