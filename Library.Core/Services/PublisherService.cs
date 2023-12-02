using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Exceptions;
using Library.Core.Services.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class PublisherService : IPublisherService
{
    private readonly IMapper _mapper;
    private readonly UNIDULibraryDbContext _context;

    public PublisherService(IMapper mapper, UNIDULibraryDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PublisherDto> AddPublisherAsync(string publisherName)
    {
        var deparmtentDto = new PublisherDto(publisherName);

        var publisher = _mapper.Map<Publisher>(deparmtentDto);

        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();

        return _mapper.Map<PublisherDto>(publisher);
    }

    public async Task<Publisher> GetPublisherByIdAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);

        if (publisher is null)
        {
            throw new NotFoundException($"Publisher with id {id} not found");
        }

        return publisher;
    }

    public async Task<IEnumerable<PublisherDto>> GetPublishersAsync()
    {
        var publishers = await _context.Publishers.ToListAsync();
        return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
    }

    public async Task<PublisherDto> UpdatePublisherAsync(int id, string publisherName)
    {
        var publisher = await GetPublisherByIdAsync(id);

        publisher.PublisherName = publisherName;

        await _context.SaveChangesAsync();

        return _mapper.Map<PublisherDto>(publisher);
    }

    public async Task<bool> DeletePublisherAsync(int id)
    {
        var publisher = await GetPublisherByIdAsync(id);

        _context.Publishers.Remove(publisher);
        await _context.SaveChangesAsync();

        return true;
    }
}
