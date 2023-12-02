namespace Library.Data.Entities;

public class Fine
{
    public Guid FineId { get; set; } = new Guid();
    public Guid LoanId { get; set; }
    public decimal Amount { get; set; }
    public bool PaidStatus { get; set; }
    public DateTime IssueDate { get; set; }
    public required Loan Loan { get; set; }
}