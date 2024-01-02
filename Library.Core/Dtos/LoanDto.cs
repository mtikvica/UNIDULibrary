namespace Library.Core.Dtos;
public class LoanDto(Guid copyId, Guid studentId)
{
    public Guid CopyId { get; set; } = copyId;
    public Guid StudentId { get; set; } = studentId;
}
