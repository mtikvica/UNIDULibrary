using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Extensions;
using Library.Core.Requests;
using Library.Core.Responses.PaginatedResponses;
using Library.Core.Responses.StudentResponses;
using Library.Core.Services.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class StudentService(UNIDULibraryDbContext context, IMapper mapper) : IStudentService
{
    private readonly UNIDULibraryDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResponse> GetAllStudentsAsync(PageRequest request)
    {
        var students = await _context.Students.AsNoTracking()
                            .Include(x => x.Department)
                            .Paginate(request.PageNumber, request.PageSize).OrderBy(x => x.Surname)
                            .ToListAsync();

        var paginatedResponse = new PaginatedResponse
        {
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = (int)Math.Ceiling((double)students.Count / request.PageSize),
            TotalRecords = students.Count,
            Records = students.Select(x => _mapper.Map<StudentResponse>(x))
        };

        return paginatedResponse;
    }

    public async Task<StudentResponse> GetStudentResponseByIdAsync(Guid studentId)
    {
        var student = await _context.Students.Include(x => x.Department).FirstOrDefaultAsync(x => x.StudentId == studentId);

        return _mapper.Map<StudentResponse>(student);
    }

    public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
    {
        var student = _mapper.Map<Student>(studentDto);

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return studentDto;
    }

    public async Task<StudentResponse> UpdateStudentAsync(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return _mapper.Map<StudentResponse>(student);
    }

    public async Task<bool> DeleteStudentAsync(Guid studentId)
    {
        var student = await GetByStudentIdAsync(studentId);

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return true;
    }

    private async Task<Student> GetByStudentIdAsync(Guid studentId)
    {
        var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == studentId);

        return student is null ? throw new NotFoundException($"Student with id: {studentId} was not found") : student;
    }

    public async Task<Student> GetStudentByEmailAndPassword(string email, string password)
    {
        var student = await _context.Students.Include(x => x.Department).FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

        return student is null ? throw new NotFoundException($"Student with email: {email} was not found") : student;
    }
}
