using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class PublisherService(IMapper mapper, IPublisherRepository publisherRepository) : IPublisherService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublisherRepository _publisherRepository = publisherRepository;

    public async Task<PublisherDto> AddPublisherAsync(string publisherName)
    {
        var deparmtentDto = new PublisherDto(publisherName);

        var publisher = _mapper.Map<Publisher>(deparmtentDto);

        await _publisherRepository.AddAsync(publisher);

        return _mapper.Map<PublisherDto>(publisher);
    }

    public async Task<Publisher> GetPublisherByIdAsync(int id)
    {
        var publisher = await _publisherRepository.GetBy(x => x.PublisherId == id).FirstOrDefaultAsync();
        return publisher is null ? throw new NotFoundException($"Publisher with id {id} not found") : publisher;
    }

    public async Task<IEnumerable<PublisherDto>> GetPublishersAsync()
    {
        var publishers = await _publisherRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
    }

    public async Task<PublisherDto> UpdatePublisherAsync(Publisher publisher)
    {
        await _publisherRepository.UpdateAsync(publisher);

        return _mapper.Map<PublisherDto>(publisher);
    }

    public async Task DeletePublisherAsync(int id)
    {
        await _publisherRepository.DeleteAsync(id);
    }
}
