using Library.Core.Dtos;
using Library.Core.Requests;
using Library.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromQuery] PageRequest request)
    {
        var students = await _studentService.GetAllStudentsAsync(request);
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        var student = await _studentService.GetStudentResponseByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
    {
        var student = await _studentService.AddStudentAsync(studentDto);
        return Created("Student created succesfully", student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentDto studentDto)
    {
        var student = await _studentService.UpdateStudentAsync(id, studentDto);
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        await _studentService.DeleteStudentAsync(id);
        return NoContent();
    }
}
