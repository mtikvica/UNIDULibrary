using Library.Domain.Abstractions;
using Library.Domain.Books;

namespace Library.Domain.Locations;

public class Location : Entity
{
    private Location(string locationName)
    {
        LocationName = locationName;
    }

    public string LocationName { get; }
    public ICollection<Book> Books { get; } = new List<Book>();

    public static Location Create(string locationName)
    {
        return new Location(locationName);
    }
}