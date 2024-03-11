namespace Library.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("OpenLibraryClient", config =>
        {
            config.BaseAddress = new Uri("https://openlibrary.org");
        });
    }
}
