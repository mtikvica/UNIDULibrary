namespace Library.Domain.Loans;

public record LoanDateRange
{
    private LoanDateRange(DateOnly loanedDate, DateOnly dueDate)
    {
        LoanedDate = loanedDate;
        DueDate = dueDate;
    }

    public DateOnly LoanedDate { get; init; }
    public DateOnly? ReturnedDate { get; set; }
    public DateOnly DueDate { get; init; }

    public static LoanDateRange Create(DateTime date)
    {
        var loanedDateTime = DateOnly.FromDateTime(date);

        var dueDateTime = loanedDateTime.AddDays(14);

        return new LoanDateRange(loanedDateTime, dueDateTime);
    }

    public bool IsOverdue()
    {
        if (ReturnedDate is not null)
        {
            return DueDate < ReturnedDate;
        }
        return false;
    }

    public bool Contains(DateOnly date)
    {
        return LoanedDate <= date && date <= ReturnedDate;
    }
}