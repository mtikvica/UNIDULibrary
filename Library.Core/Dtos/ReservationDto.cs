namespace Library.Core.Dtos;
public class ReservationDto(Guid copyId, Guid studentID)
{
    public Guid ReservationId { get; private set; } = Guid.NewGuid();
    public Guid StudentId { get; private set; } = studentID;
    public Guid BookCopyId { get; private set; } = copyId;
    public DateTime ReservationDate { get; private set; } = DateTime.Now;
    public DateTime ExpirationDate { get; private set; } = SetExpirationDate();
    public bool IsProcessed { get; private set; } = false;

    public static DateTime SetExpirationDate()
    {
        var dayOfWeek = DateTime.Now.DayOfWeek;

        if (dayOfWeek == DayOfWeek.Saturday)
        {
            return DateTime.Now.AddDays(Constants.ReservationExpiryDays);
        }
        else if (dayOfWeek == DayOfWeek.Sunday)
        {
            return DateTime.Now.AddDays(Constants.ReservationExpiryDays);
        }

        return DateTime.Now.AddDays(Constants.ReservationExpiryDays);
    }
}
