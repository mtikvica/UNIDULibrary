namespace Library.Data.Entities;

public class Staff : User
{
    public Guid StaffId { get; set; } = new Guid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}