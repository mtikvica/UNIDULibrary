using Library.Domain.Abstractions;

namespace Library.Domain.InventoryStates;

public sealed class InventoryState : Entity
{
    public Guid BookId { get; }
    public int AvailableCount { get; } = 1;
    public int BorrowedCount { get; } = 0;
    public int ReservedCount { get; } = 0;
    public DateTime LastUpdated { get; } = DateTime.Now;
}