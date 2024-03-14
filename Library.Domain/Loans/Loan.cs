using Library.Domain.Abstractions;

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
        return new Loan(bookCopyId, studentId, date);
    }

    public int CalculateOverdueDays()
    {
        if (DateRange.IsOverdue() && DateRange.ReturnedDate is not null)
        {
            var date = (DateOnly)DateRange.ReturnedDate;
            return date.DayNumber - DateRange.DueDate.DayNumber;
        }
        return 0;
    }

    public void Return(DateOnly returnDate)
    {
        LoanStatus = LoanStatus.Returned;
        DateRange.ReturnedDate = returnDate;
    }
}