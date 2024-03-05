using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Extensions;

public static class ApplicationMigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        using var context = serviceScope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
}
