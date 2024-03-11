using Bogus;
using Library.Application.Abstractions.Data;
using Library.Application.Books.CreateBookWithOpenLibrary;
using MediatR;

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

        var mediator = serviceScope.ServiceProvider.GetRequiredService<IMediator>();

        var books = new string[] { "9780134494166", "9780134494326", "OL1718405M", "OL37983797M" };

        foreach (var isbn in books)
        {
            var bookCommand = new CreateBookCommand(isbn);
            mediator.Send(bookCommand);
        }

    }
}
