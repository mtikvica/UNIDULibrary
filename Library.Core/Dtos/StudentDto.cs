using Library.Core.Enums;
using Library.Core.Helpers;
using System.Text.Json.Serialization;

namespace Library.Core.Dtos;
public class StudentDto(string name, string surname, string email, string password, int departmentId, int year)
{
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string Email { get; set; } = email;
    public string Password { get; set; } = PasswordHashHelper.HashPassword(password);
    public int DepartmentId { get; set; } = departmentId;
    public int Year { get; set; } = year;
    [JsonIgnore]
    public int RoleId => (int)RolesEnums.Student;
}
