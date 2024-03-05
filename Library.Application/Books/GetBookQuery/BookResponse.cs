namespace Library.Application.Books.GetBookQuery;

public sealed class BookResponse
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public required List<AuthorResponse> Authors { get; init; } = [];
    public int? NumberOfPages { get; init; }
    public required string PublisherName { get; init; }
    public int? PublicationYear { get; init; }
    public required string ISBN { get; init; }
}