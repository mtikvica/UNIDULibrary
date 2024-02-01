namespace Library.Domain.Loans;

public record LoanDateRange
{
    private LoanDateRange(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public DateOnly? DueDate { get; init; }

    public static LoanDateRange Create()
    {
        var StartDateTime = DateOnly.FromDateTime(DateTime.Now);

        var EndDateTime = StartDateTime.AddDays(14);

        return new LoanDateRange(StartDateTime, EndDateTime);
    }

    public bool Overlaps(LoanDateRange dateRange)
    {
        return StartDate < dateRange.EndDate && dateRange.StartDate < EndDate;
    }

    public bool Contains(DateOnly date)
    {
        return StartDate <= date && date <= EndDate;
    }
}