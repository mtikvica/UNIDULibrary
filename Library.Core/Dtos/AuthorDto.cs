namespace Library.Core.Dtos;
public class AuthorDto(string authorOpenLibraryKey, string authorName)
{
    public string AuthorOpenLibraryKey { get; set; } = authorOpenLibraryKey;
    public string AuthorName { get; set; } = authorName;
}
