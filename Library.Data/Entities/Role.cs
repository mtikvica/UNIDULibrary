namespace Library.Data.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public ICollection<Staff> Staff { get; set; } = new List<Staff>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
}