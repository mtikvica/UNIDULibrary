using Library.Domain.Abstractions;

namespace Library.Domain.Loans;
public static class LoanErrors
{
    public static Error AlreadyReturned = new(
                "Loan.AlreadyReturned",
                "Loan is already returned!"
               );
    public static Error NotReturned = new(
                "Loan.NotReturned",
                "Loan is not returned!"
               );
    public static Error Overdue = new(
                "Loan.Overdue",
                "Loan is overdue!"
               );
}
