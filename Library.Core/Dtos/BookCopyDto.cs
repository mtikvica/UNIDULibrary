namespace Library.Core.Dtos;
public class BookCopyDto(Guid bookId)
{
    public Guid BookId { get; set; } = bookId;
}
