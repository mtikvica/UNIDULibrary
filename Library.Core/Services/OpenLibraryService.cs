using Library.Core.Responses.OpenLibraryModels;
using Library.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace Library.Core.Services;
public class OpenLibraryService : IOpenLibraryService
{
    private readonly HttpClient _httpClient;

    public OpenLibraryService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("OpenLibraryClient");
    }

    public async Task<OpenLibraryBookResponse> GetBookDetailsAsync(string isbn)
    {
        var apiUrl = $"isbn/{isbn}.json";

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<OpenLibraryBookResponse>(json);
            return book ?? new();
        }
        throw new HttpRequestException($"Failed to retrieve book details. Status Code: {response.StatusCode}");
    }
}