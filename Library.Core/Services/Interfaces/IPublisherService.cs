using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IPublisherService
{
    Task<PublisherDto> AddPublisherAsync(string publisherDto);
    Task<bool> DeletePublisherAsync(int id);
    Task<Publisher> GetPublisherByIdAsync(int id);
    Task<IEnumerable<PublisherDto>> GetPublishersAsync();
    Task<PublisherDto> UpdatePublisherAsync(int id, string publisherName);
}