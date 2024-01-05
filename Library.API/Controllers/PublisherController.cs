using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPublishersAsync()
    {
        var publishers = await _publisherService.GetPublishersAsync();
        return Ok(publishers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublisherByIdAsync(int id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);
        return Ok(publisher);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePublisherAsync(string publisherName)
    {
        var publisher = await _publisherService.AddPublisherAsync(publisherName);
        return Created("Publisher created successfully!", publisher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePublisherAsync(Publisher publisher)
    {
        var response = await _publisherService.UpdatePublisherAsync(publisher);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublisherAsync(int id)
    {
        await _publisherService.DeletePublisherAsync(id);
        return NoContent();
    }
}
