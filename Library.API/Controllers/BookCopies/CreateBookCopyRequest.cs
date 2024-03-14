namespace Library.API.Controllers.BookCopies;

public class CreateBookCopyRequest
{
    public Guid BookId { get; set; }
    public int Ammount { get; set; }
}
