namespace Library.Data.Entities;

public class Reservation
{
    public Guid ReservationId { get; set; } = new Guid();
    public Guid StudentId { get; set; }
    public Guid BookCopyId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public required Student Student { get; set; }
    public required BookCopy BookCopy { get; set; }
}