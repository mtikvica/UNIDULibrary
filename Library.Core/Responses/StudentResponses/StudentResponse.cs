namespace Library.Core.Responses.StudentResponses;
public class StudentResponse
{
    public Guid StudentId { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Department { get; set; } = null!;
    public int Year { get; set; }
}
