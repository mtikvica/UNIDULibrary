using Bogus;
using Dapper;
using Library.API.SeedData.Models;
using Library.Domain.Users;
using System.Data;

namespace Library.API.SeedData;

public static class EmployeeDataSeed
{
    public static void Seed(Faker faker, IDbConnection connection, List<LocationSeedModel> locations)
    {
        var employees = new List<object>();

        foreach (var location in locations)
        {
            var employee = new
            {
                Id = Guid.NewGuid(),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = faker.Internet.Email(),
                Password = Password.Create("Password1").Value,
                LocationId = location.Id
            };
            employees.Add(employee);
        }

        const string sql = "INSERT INTO [dbo].[Employee] ([Id], [FirstName], [LastName], [Email], [Password], [LocationId]) VALUES (@Id, @FirstName, @LastName, @Email, @Password, @LocationId)";
        connection.Execute(sql, employees);
    }
}
