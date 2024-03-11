using Library.Domain.Abstractions;

namespace Library.Domain.Locations;

public sealed class Location : Entity
{
    private Location(string street, string city, string country, string zipCode)
    {
        Address = Address.Create(street, city, country, zipCode);
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Location() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Address Address { get; }

    public static Location Create(string street, string city, string country, string zipCode)
    {
        return new Location(street, city, country, zipCode);
    }
}