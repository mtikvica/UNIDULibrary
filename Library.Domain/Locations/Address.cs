namespace Library.Domain.Locations;

public sealed record Address
{
    private Address(string Street, string City, string ZipCode, string Country)
    {
        this.Street = Street;
        this.City = City;
        this.ZipCode = ZipCode;
        this.Country = Country;
    }

    public string Street { get; init; }
    public string City { get; init; }
    public string ZipCode { get; init; }
    public string Country { get; init; }

    public static Address Create(string Street, string City, string ZipCode, string Country)
    {
        return new Address(Street, City, ZipCode, Country);
    }
}