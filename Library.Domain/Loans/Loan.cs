using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Loans.Event;

namespace Library.Domain.Loans;

public sealed class Loan : Entity
{
    private Loan(Guid bookCopyId, Guid studentId)
    {
        BookCopyId = bookCopyId;
        StudentId = studentId;
    }

    public Guid BookCopyId { get; }
    public Guid StudentId { get; }
    public LoanDateRange DateRange { get; } = LoanDateRange.Create();
    public LoanStatus LoanStatus { get; private set; }

    public static Loan Create(BookCopy bookCopy, Guid studentId)
    {
        var loan = new Loan(bookCopy.Id, studentId);

        bookCopy.ProcessLoan();

        loan.RaiseDomainEvent(new LoanCreatedDomainEvent(loan.Id));

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