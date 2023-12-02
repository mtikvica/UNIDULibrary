using Library.Core.Enums;
using System.Text.Json.Serialization;

namespace Library.Core.Dtos;
public class StudentDto
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int DepartmentId { get; set; }
    public int Year { get; set; }
    [JsonIgnore]
    public int RoleId => (int)RolesEnums.Student;
}
