namespace Library.Data.Entities;

public class InventoryState
{
    public Guid InventoryStateId { get; set; } = new Guid();
    public Guid BookId { get; set; }
    public int? AvailableCount { get; set; } = 1;
    public int? BorrowedCount { get; set; } = 0;
    public int? ReservedCount { get; set; } = 0;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public required Book Book { get; set; }
}