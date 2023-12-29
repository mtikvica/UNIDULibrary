using Library.Core.Dtos;
using Library.Core.Requests;
using Library.Core.Responses.PaginatedResponses;
using Library.Core.Responses.StudentResponses;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IStudentService
{
    Task<StudentDto> AddStudentAsync(StudentDto studentDto);
    Task<bool> DeleteStudentAsync(Guid studentId);
    Task<PaginatedResponse> GetAllStudentsAsync(PageRequest request);
    Task<StudentResponse> GetStudentResponseByIdAsync(Guid studentId);
    Task<StudentResponse> UpdateStudentAsync(Student student);
    Task<StudentResponse> GetStudentByEmailAndPassword(string email, string password);
}