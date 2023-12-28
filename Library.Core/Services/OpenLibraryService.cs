using Library.Core.Responses.OpenLibraryModels;
using Library.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace Library.Core.Services;
public class OpenLibraryService(IHttpClientFactory httpClientFactory) : IOpenLibraryService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenLibraryClient");

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

    public async Task<OpenLibraryAuthorResponse> GetAuthorAsync(string authorOLCode)
    {
        var apiUrl = $"{authorOLCode}.json";

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var author = JsonConvert.DeserializeObject<OpenLibraryAuthorResponse>(json);
            return author ?? new();
        }
        throw new HttpRequestException($"Failed to retrieve author details. Status Code: {response.StatusCode}");
    }
}