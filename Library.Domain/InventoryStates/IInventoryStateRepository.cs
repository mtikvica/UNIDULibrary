namespace Library.Domain.InventoryStates;
internal interface IInventoryStateRepository
{
    Task<InventoryState> GetByIdAsyncAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<InventoryState>> GetAllAsync(CancellationToken cancellationToken = default);

    void Add(InventoryState inventoryState);
    void Update(InventoryState inventoryState);
    void Delete(InventoryState inventoryState);
}
