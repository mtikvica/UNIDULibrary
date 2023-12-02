namespace Library.Data.Entities;

public class Student : User
{
    public Guid StudentId { get; set; } = new Guid();
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int Year { get; set; }
    public int DepartmentId { get; set; }
    public required Department Department { get; set; }
    public required IEnumerable<Reservation> Reservation { get; set; }
    public required IEnumerable<Loan> Loan { get; set; }
}