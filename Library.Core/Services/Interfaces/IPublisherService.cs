using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IPublisherService
{
    Task<PublisherDto> AddPublisherAsync(string publisherDto);
    Task DeletePublisherAsync(int id);
    Task<Publisher> GetPublisherByIdAsync(int id);
    Task<IEnumerable<PublisherDto>> GetPublishersAsync();
    Task<PublisherDto> UpdatePublisherAsync(Publisher publisher);
}