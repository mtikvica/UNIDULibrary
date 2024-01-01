using AutoMapper;
using Library.Core.Dtos;
using Library.Data.Entities;
using Library.Data.Repositories;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class InventoryStateService(IInventoryStateRepository inventoryStateRepository, IBookRepository bookRepository, IMapper mapper) : IInventoryStateService
{
    private readonly IInventoryStateRepository _inventoryStateRepository = inventoryStateRepository;
    private readonly IMapper _mapper = mapper;

    public async Task ModifyInventoryStateAvailableCount(Guid bookId, int ammount)
    {
        var inventory = await _inventoryStateRepository.GetBy(x => x.BookId == bookId).FirstOrDefaultAsync();

        if (inventory is null)
        {
            var inventoryStateDto = new InventoryStateDto
            {
                BookId = bookId,
                AvailableCount = ammount
            };

            await _inventoryStateRepository.AddAsync(_mapper.Map<InventoryState>(inventoryStateDto));
            return;
        }

        inventory.AvailableCount += ammount;

        await _inventoryStateRepository.UpdateAsync(inventory);
    }
}
