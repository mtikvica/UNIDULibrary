namespace Library.Core.Dtos;
public class ReservationDto(Guid copyId, Guid studentID)
{
    public Guid StudentId { get; set; } = studentID;
    public Guid BookCopyId { get; set; } = copyId;
}
