
namespace Library.API.SeedData.Models;

public class LocationSeedModel
{
    public Guid Id { get; internal set; }
    public string City { get; internal set; } = null!;
    public string Street { get; internal set; } = null!;
    public string ZipCode { get; internal set; } = null!;
    public string Country { get; internal set; } = null!;
}
