
namespace Library.Core.Services;

public interface IInventoryStateService
{
    Task ModifyInventoryStateAvailableCount(Guid bookId, int ammount);
}