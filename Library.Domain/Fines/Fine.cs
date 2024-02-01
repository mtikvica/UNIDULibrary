namespace Library.Domain.Fines;

public sealed class Fine
{
    public Guid FineId { get; } = new Guid();
    public Guid LoanId { get; }
    public decimal Amount { get; }
    public bool PaidStatus { get; }
    public DateTime IssueDate { get; } = DateTime.Now;
}