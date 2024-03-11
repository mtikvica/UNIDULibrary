namespace Library.Application.Fines;

public class FineResponse
{
    public Guid Id { get; }
    public decimal Amount { get; }
    public bool IsPaid { get; }
    public DateTime IssueDate { get; }
}