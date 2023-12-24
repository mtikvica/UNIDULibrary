using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class LocationService(ILocationRepository locationRepository, IMapper mapper) : ILocationService
{
    private readonly ILocationRepository _locationRepository = locationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
    {
        var locations = await _locationRepository.GetAllAsync();
        return locations.Select(x => _mapper.Map<LocationDto>(x)).ToList();
    }

    public async Task<Location> GetLocationAsync(int id)
    {
        var location = await _locationRepository.GetBy(x => x.LocationId == id).FirstOrDefaultAsync();

        return location is null ? throw new NotFoundException($"Location with id: {id} was not found!") : location;
    }

    public async Task<LocationDto> AddLocationAsync(string locationName)
    {
        var locationDto = new LocationDto(locationName);

        var location = _mapper.Map<Location>(locationDto);

        await _locationRepository.AddAsync(location);

        return _mapper.Map<LocationDto>(location);
    }

    public async Task<bool> DeleteLocationAsync(int id)
    {
        var location = await GetLocationAsync(id);

        await _locationRepository.DeleteAsync(location);

        return true;
    }

    public async Task<LocationDto> UpdateLocationAsync(Location location)
    {
        await _locationRepository.UpdateAsync(location);

        return _mapper.Map<LocationDto>(location);
    }
}
