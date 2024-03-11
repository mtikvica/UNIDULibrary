using Library.Application.Students.GetStudentQuery;
using Library.Application.Students.GetStudentsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Students;
[Route("api/[controller]")]
[ApiController]
public class StudentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        var query = new GetStudentQuery(id);
        var student = await _mediator.Send(query);

        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetStudentsQuery(page, pageSize);
        var students = await _mediator.Send(query);

        return Ok(students);
    }
}
