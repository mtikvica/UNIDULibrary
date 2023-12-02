using Library.Core.Services;
using Library.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Core.DependencyInjection;
public static class DependencyInjection
{

    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IOpenLibraryService, OpenLibraryService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IPublisherService, PublisherService>();
    }
}
