using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("departments")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentService.GetDeparmentsAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var department = await _departmentService.GetDepartmentAsync(id);
        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> AddDepartment(string departmentName)
    {
        var department = await _departmentService.AddDepartmentAsync(departmentName);
        return Created("Department created succesfully", department);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(Department department)
    {
        var response = await _departmentService.UpdateDepartmentAsync(department);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _departmentService.DeleteDepartmentAsync(id);
        return NoContent();
    }
}
