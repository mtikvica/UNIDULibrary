using Library.Core.Enums;
using Library.Core.Helpers;

namespace Library.Core.Dtos;
public class StaffDto(string firstName, string lastName, string email, string password)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public string Password { get; set; } = PasswordHashHelper.HashPassword(password);
    public int RoleId => (int)RolesEnums.Librarian;
}
