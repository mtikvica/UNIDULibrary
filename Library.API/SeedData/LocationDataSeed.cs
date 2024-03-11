using Dapper;
using Library.API.SeedData.Models;
using System.Data;

namespace Library.API.SeedData;

public static class LocationDataSeed
{
    public static List<LocationSeedModel> Seed(IDbConnection connection)
    {
        var streetNames = new List<string> { SeedConstants.CiraCarica, SeedConstants.LapadskaObala, SeedConstants.Kampus };
        var locationIds = new List<Guid>();

        var locations = new List<LocationSeedModel>();
        foreach (var street in streetNames)
        {
            var locationId = Guid.NewGuid();
            locationIds.Add(locationId);

            var location = new LocationSeedModel
            {
                Id = locationId,
                City = "Dubrovnik",
                Street = street,
                ZipCode = "2000",
                Country = "Croatia"
            };
            locations.Add(location);
        }
        const string sql = "INSERT INTO [dbo].[Location] ([Id], [City], [Street], [ZipCode], [Country]) VALUES (@Id, @City, @Street, @ZipCode, @Country)";
        connection.Execute(sql, locations);

        return locations;
    }
}
