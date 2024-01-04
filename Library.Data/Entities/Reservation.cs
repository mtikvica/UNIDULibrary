namespace Library.Data.Entities;

public class Reservation
{
    public Guid ReservationId { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid BookCopyId { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public bool IsProcessed { get; private set; }
    public required Student Student { get; set; }
    public required BookCopy BookCopy { get; set; }

    public Reservation(Guid studentId, Guid bookCopyId)
    {
        ReservationId = Guid.NewGuid();
        StudentId = studentId;
        BookCopyId = bookCopyId;
        ReservationDate = DateTime.Now;
        ExpirationDate = DateTime.Now.Date.AddDays(1);
        IsProcessed = false;
    }

    public void ProcessReservation()
    {
        // Add business logic to process the reservation
        IsProcessed = true;
    }

    public void ExtendExpirationDate(int days)
    {
        // Add business logic to extend the expiration date
        ExpirationDate = ExpirationDate.AddDays(days);
    }
}
