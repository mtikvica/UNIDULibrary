namespace Library.Application.Shared;
internal sealed class PaginatedResponse<T>
{
    public PaginatedResponse(IEnumerable<T> data, int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
        Returned = data.Count();
        Data = data;
    }

    public int Page { get; }
    public int PageSize { get; }
    public int Returned { get; set; }
    public IEnumerable<T> Data { get; }
}
