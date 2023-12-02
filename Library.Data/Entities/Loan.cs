namespace Library.Data.Entities;

public class Loan
{
    public Guid LoanId { get; set; } = new Guid();
    public Guid CopyId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? LoanStatus { get; set; }
    public required BookCopy Copy { get; set; }
    public required Student Student { get; set; }
    public required Fine Fines { get; set; }
}