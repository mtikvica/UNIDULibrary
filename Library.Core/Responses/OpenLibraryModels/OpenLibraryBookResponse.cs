using Newtonsoft.Json;

namespace Library.Core.Responses.OpenLibraryModels;
public class OpenLibraryBookResponse
{
    public string Title { get; set; } = string.Empty;

    [JsonProperty("publish_date")]
    public string? PublishDate { get; set; }
    public List<string> Publishers { get; set; } = [];
    public List<AuthorCodes> Authors { get; set; } = [];
    public List<string> Subjects { get; set; } = [];

    [JsonProperty("number_of_pages")]
    public int NumberOfPages { get; set; }

    [JsonProperty("isbn_10")]
    public List<string> Isbn10 { get; set; } = new List<string>();
}