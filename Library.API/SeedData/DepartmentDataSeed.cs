using Dapper;
using Library.API.SeedData.Models;
using System.Data;

namespace Library.API.SeedData;

public static class DepartmentDataSeed
{
    public static List<DepartmentSeedModel> Seed(IDbConnection connection, List<LocationSeedModel> locations)
    {
        var departments = new List<DepartmentSeedModel>
        {
            new() {
                Id = Guid.NewGuid(),
                Name = SeedConstants.Computing,
                LocationId = locations.Where(x => x.Street.Equals(SeedConstants.CiraCarica)).Select(x => x.Id).FirstOrDefault(),
            },
            new() {
                Id = Guid.NewGuid(),
                Name = SeedConstants.Economics,
                LocationId = locations.Where(x => x.Street.Equals(SeedConstants.LapadskaObala)).Select(x => x.Id).FirstOrDefault(),
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = SeedConstants.ITManagement,
                LocationId = locations.Where(x => x.Street.Equals(SeedConstants.Kampus)).Select(x => x.Id).FirstOrDefault(),
            },
        };

        const string sql = "INSERT INTO Department ([Id], [Name], [LocationId]) VALUES (@Id, @Name, @LocationId)";

        connection.Execute(sql, departments);

        return departments;
    }
}
