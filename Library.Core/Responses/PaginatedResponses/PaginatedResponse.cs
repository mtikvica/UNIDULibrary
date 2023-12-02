namespace Library.Core.Responses.PaginatedResponses;
public class PaginatedResponse
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public IEnumerable<object> Records { get; set; } = null!;
}
