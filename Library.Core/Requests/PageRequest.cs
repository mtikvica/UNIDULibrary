namespace Library.Core.Requests;
public class PageRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
