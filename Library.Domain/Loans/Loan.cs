using Library.Domain.Abstractions;
using Library.Domain.Loans.Event;

namespace Library.Domain.Loans;

public sealed class Loan : Entity
{
    private Loan(Guid bookCopyId, Guid studentId, DateTime date)
    {
        BookCopyId = bookCopyId;
        StudentId = studentId;
        DateRange = LoanDateRange.Create(date);
    }

    private Loan() { }

    public Guid BookCopyId { get; }
    public Guid StudentId { get; }
    public LoanDateRange DateRange { get; }
    public LoanStatus LoanStatus { get; private set; }

    public static Loan Create(Guid studentId, Guid bookCopyId, DateTime date)
    {
        var loan = new Loan(bookCopyId, studentId, date);

        loan.RaiseDomainEvent(new LoanCreatedDomainEvent(bookCopyId));

        return loan;
    }

    public bool IsOverdue()
    {
        return DateRange.DueDate < DateRange.EndDate;
    }

    public Loan Return()
    {
        LoanStatus = LoanStatus.Returned;
        return this;
    }
}