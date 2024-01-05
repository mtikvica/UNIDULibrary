namespace Library.Data.Entities;

public class Reservation()
{
    public Guid ReservationId { get; private set; } = Guid.NewGuid();
    public Guid StudentId { get; private set; }
    public Guid BookCopyId { get; private set; }
    public DateTime ReservationDate { get; private set; } = DateTime.Now;
    public DateTime ExpirationDate { get; private set; } = DateTime.Now.Date.AddDays(1);
    public bool IsProcessed { get; private set; } = false;
    public required Student Student { get; set; }
    public required BookCopy BookCopy { get; set; }

    public void ProcessReservation()
    {
        IsProcessed = true;
    }

    public void ExtendExpirationDate(int days)
    {
        ExpirationDate = ExpirationDate.AddDays(days);
    }
}
