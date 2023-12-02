﻿using Library.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("[controller]")]
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
    public async Task<IActionResult> UpdatePublisherAsync(int id, string publisherName)
    {
        var publisher = await _publisherService.UpdatePublisherAsync(id, publisherName);
        return Ok(publisher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublisherAsync(int id)
    {
        await _publisherService.DeletePublisherAsync(id);
        return NoContent();
    }
}