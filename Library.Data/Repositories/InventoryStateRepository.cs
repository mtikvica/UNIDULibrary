using Library.Data.Context;
using Library.Data.Entities;

namespace Library.Data.Repositories;
public class InventoryStateRepository(UNIDULibraryDbContext context) : Repository<InventoryState>(context), IInventoryStateRepository
{
}
