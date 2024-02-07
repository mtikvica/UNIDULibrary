using Library.Domain.Abstractions;

namespace Library.Domain.Fines;

public sealed class Fine : Entity
{
    private Fine(Guid loanId, decimal amount, bool paidStatus, DateTime issueDate)
    {
        LoanId = loanId;
        Amount = amount;
        PaidStatus = paidStatus;
        IssueDate = issueDate;
    }

    public Guid LoanId { get; }
    public decimal Amount { get; }
    public bool PaidStatus { get; }
    public DateTime IssueDate { get; }

    public static Fine Create(Guid loanId, decimal amount, bool paidStatus, DateTime issueDate)
    {
        return new Fine(loanId, amount, paidStatus, issueDate);
    }
}