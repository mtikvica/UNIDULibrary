using Newtonsoft.Json;

namespace Library.Core.Responses.OpenLibraryModels;
public class OpenLibraryBookResponse
{
    public string Title { get; set; } = string.Empty;

    [JsonProperty("publish_date")]
    public DateTime PublishDate { get; set; }
    public List<string> Publishers { get; set; } = new();
    public List<string> Subjects { get; set; } = new();

    [JsonProperty("number_of_pages")]
    public int NumberOfPages { get; set; }
}