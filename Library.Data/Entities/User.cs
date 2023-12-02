namespace Library.Data.Entities;
public class User
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int RoleId { get; set; }
    public required Role Role { get; set; }
}
