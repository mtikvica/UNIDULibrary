using Library.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Extensions;

public static class ServiceExtensions
{
    public static void AddContext(this IServiceCollection services)
    {
        services.AddDbContext<UNIDULibraryDbContext>(
        options => options.UseSqlServer("name=DefaultConnection"));
    }

    public static void ConfigureHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("OpenLibraryClient", config =>
        {
            config.BaseAddress = new Uri("https://openlibrary.org");
        });
    }
}
