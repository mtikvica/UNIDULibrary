using Bogus;
using Dapper;
using Library.API.SeedData.Models;
using Library.Domain.Users;
using System.Data;

namespace Library.API.SeedData;

public static class StudentDataSeed
{
    public static void Seed(Faker faker, IDbConnection connection, List<DepartmentSeedModel> departments)
    {
        var students = new List<object>();

        var departmentGuids = departments.ConvertAll(x => x.Id);

        for (var i = 0; i < 100; i++)
        {
            var student = new
            {
                Id = Guid.NewGuid(),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = faker.Internet.Email(),
                Password = Password.Create(SeedPassword()).Value,
                AcademicYear = faker.Random.Int(1, 5),
                DepartmentId = departmentGuids[faker.Random.Int(0, departmentGuids.Count - 1)]
            };
            students.Add(student);
        }

        const string sql = "INSERT INTO [dbo].[Student] ([Id], [FirstName], [LastName], [Email], [Password], [AcademicYear], [DepartmentId]) VALUES (@Id, @FirstName, @LastName, @Email, @Password, @AcademicYear, @DepartmentId)";

        connection.Execute(sql, students);
    }

    private static string SeedPassword()
    {
        return "Password1";
    }
}
