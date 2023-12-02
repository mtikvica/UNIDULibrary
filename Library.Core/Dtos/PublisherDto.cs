namespace Library.Core.Dtos;
public class PublisherDto
{
    public PublisherDto(string publisherName)
    {
        PublisherName = publisherName;
    }

    public int PublisherId { get; set; }
    public string PublisherName { get; set; } = null!;
}
