namespace Library.Domain.InventoryStates;
public class InventoryCount
{
    public int AvailableCount { get; private set; } = 1;
    public int BorrowedCount { get; private set; }
    public int ReservedCount { get; private set; }

    public static InventoryCount Create(int availableCount, int borrowedCount, int reservedCount)
    {
        return new InventoryCount
        {
            AvailableCount = availableCount,
            BorrowedCount = borrowedCount,
            ReservedCount = reservedCount
        };
    }

    public void Validate()
    {
        if (AvailableCount < 0 || BorrowedCount < 0 || ReservedCount < 0)
        {
            throw new ArgumentException("Inventory count cannot be negative");
        }
    }
}
