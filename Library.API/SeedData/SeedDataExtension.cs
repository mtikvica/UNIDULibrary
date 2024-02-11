using Bogus;
using Library.Application.Abstractions.Data;

namespace Library.API.SeedData;

public static class SeedDataExtension
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = serviceScope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker("en");

        var locations = LocationDataSeed.Seed(connection);

        EmployeeDataSeed.Seed(faker, connection, locations);

        var departments = DepartmentDataSeed.Seed(connection, locations);

        StudentDataSeed.Seed(faker, connection, departments);
    }
}
