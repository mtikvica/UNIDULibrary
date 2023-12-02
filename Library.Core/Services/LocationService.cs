using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Exceptions;
using Library.Core.Services.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class LocationService : ILocationService
{
    private readonly UNIDULibraryDbContext _context;
    private readonly IMapper _mapper;

    public LocationService(UNIDULibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
    {
        var locations = await _context.Locations.AsNoTracking().ToListAsync();
        return locations.Select(x => _mapper.Map<LocationDto>(x)).ToList();
    }

    public async Task<Location> GetLocationAsync(int id)
    {
        var location = await _context.Locations.Where(x => x.LocationId == id).FirstOrDefaultAsync();

        if (location is null)
        {
            throw new NotFoundException($"Location with id: {id} was not found!");
        }
        return location;
    }

    public async Task<LocationDto> AddLocationAsync(string locationName)
    {
        var locationDto = new LocationDto(locationName);

        var location = _mapper.Map<Location>(locationDto);

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();

        return _mapper.Map<LocationDto>(location);
    }

    public async Task<bool> DeleteLocationAsync(int id)
    {
        var location = await GetLocationAsync(id);

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<LocationDto> UpdateLocationAsync(int id, string locationName)
    {
        var location = await GetLocationAsync(id);

        location.LocationName = locationName;

        await _context.SaveChangesAsync();

        return _mapper.Map<LocationDto>(location);
    }
}
