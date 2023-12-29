using Library.Core.Services;
using Library.Core.Services.Interfaces;
using Library.Data.Repositories;
using Library.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Core.DependencyInjection;
public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
    }

    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IOpenLibraryService, OpenLibraryService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IStaffService, StaffService>();
    }
}
