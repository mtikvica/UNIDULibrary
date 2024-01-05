using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("locations")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations()
    {
        var locations = await _locationService.GetLocationsAsync();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var location = await _locationService.GetLocationAsync(id);
        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> AddLocation(string locationName)
    {
        var location = await _locationService.AddLocationAsync(locationName);
        return Created("Location created succesfully", location);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(Location location)
    {
        var response = await _locationService.UpdateLocationAsync(location);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await _locationService.DeleteLocationAsync(id);
        return NoContent();
    }
}
