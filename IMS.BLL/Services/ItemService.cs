using IMS.BLL.DTOs.Item;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Interfaces.Services;

namespace IMS.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllItemsAsync();
        }

        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetItemByIdAsync(id);
        }

        public async Task AddItemAsync(ItemDTO itemDto)
        {
            if (itemDto == null)
                throw new ArgumentNullException(nameof(itemDto));

            if (await _itemRepository.ItemNameExistsAsync(itemDto.Name))
                throw new InvalidOperationException($"Item with name {itemDto.Name} already exists.");

            await _itemRepository.AddItemAsync(itemDto);
        }

        public async Task UpdateItemAsync(ItemDTO itemDto)
        {
            if (itemDto == null)
                throw new ArgumentNullException(nameof(itemDto));

            await _itemRepository.UpdateItemAsync(itemDto);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _itemRepository.DeleteItemAsync(id);
        }

        public async Task<bool> HasRelatedStocksAsync(int itemId)
        {
            return await _itemRepository.HasRelatedStocksAsync(itemId);
        }

        public async Task DeleteRelatedStocksAsync(int itemId)
        {
            await _itemRepository.DeleteRelatedStocksAsync(itemId);
        }
    }
}