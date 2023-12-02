using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface ILocationService
{
    Task<LocationDto> AddLocationAsync(string locationName);
    Task<bool> DeleteLocationAsync(int id);
    Task<Location> GetLocationAsync(int id);
    Task<IEnumerable<LocationDto>> GetLocationsAsync();
    Task<LocationDto> UpdateLocationAsync(int id, string locationName);
}