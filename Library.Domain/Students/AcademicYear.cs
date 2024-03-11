namespace Library.Domain.Students;
public sealed record AcademicYear
{
    private const int firstYear = 1;
    private const int lastYear = 5;

    public int Value { get; }

    private AcademicYear(int value)
    {
        Value = value;
    }

    public static AcademicYear Create(int value)
    {
        if (value < firstYear || value > lastYear)
        {
            throw new ArgumentException($"Academic year must be between {firstYear} and {lastYear}");
        }
        return new AcademicYear(value);
    }
}
