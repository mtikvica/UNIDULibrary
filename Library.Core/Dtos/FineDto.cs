namespace Library.Core.Dtos;
public class FineDto(Guid loanId, int daysOverdue)
{
    public Guid FineId { get; set; } = new Guid();
    public Guid LoanId { get; set; } = loanId;
    public decimal Amount { get; set; } = daysOverdue * Constants.FinePerDay;
    public bool PaidStatus { get; set; }
    public DateTime IssueDate { get; set; } = DateTime.Now;
}
