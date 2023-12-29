using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffService _staffService;

    public StaffController(IStaffService staffService)
    {
        _staffService = staffService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStaff(Guid id)
    {
        var staff = await _staffService.GetStaffByIdAsync(id);
        return Ok(staff);
    }

    [HttpPost]
    public async Task<IActionResult> AddStaff([FromBody] StaffDto staffDto)
    {
        var staff = await _staffService.AddStaffAsync(staffDto);
        return Created("Staff created succesfully", staff);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStaff(Guid id, [FromBody] Staff staff)
    {
        var response = await _staffService.UpdateStaffAsync(staff);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStaff(Guid id)
    {
        await _staffService.DeleteStaffAsync(id);
        return NoContent();
    }
}
