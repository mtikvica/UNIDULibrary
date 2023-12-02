namespace Library.Core.Dtos;
public class LocationDto
{
    public LocationDto(string locationName)
    {
        LocationName = locationName;
    }

    public int LocationId { get; set; }
    public string LocationName { get; set; }
}
