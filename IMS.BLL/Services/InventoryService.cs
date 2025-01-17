using IMS.BLL.DTOs.Inventory;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.BLL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        // Item-related methods
        public async Task<IEnumerable<ItemDTO>> GetUserItemsAsync(int userId)
        {
            return await _inventoryRepository.GetItemsByUserIdAsync(userId);
        }

        public async Task<ItemDTO> AddItemAsync(int userId, ItemDTO itemDto)
        {
            return await _inventoryRepository.AddItemAsync(userId, itemDto);
        }

        public async Task<ItemDTO> UpdateItemAsync(int id, UpdateItemDTO updateItemDto)
        {
            return await _inventoryRepository.UpdateItemAsync(id, updateItemDto);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _inventoryRepository.DeleteItemAsync(id);
        }

        public async Task CheckAndReorderStockAsync(int itemId, int reorderThreshold, int reorderQuantity)
        {
            var item = await _inventoryRepository.GetItemByIdAsync(itemId);
            if (item == null)
                throw new InvalidOperationException($"Item with ID {itemId} not found");

            if (item.Stock < reorderThreshold)
            {
                item.Stock += reorderQuantity;
                await _inventoryRepository.UpdateItemAsync(itemId, new UpdateItemDTO
                {
                    Id = itemId,
                    Stock = item.Stock
                });
            }
        }

        // Stock-related methods
        public async Task<IEnumerable<StockDTO>> GetItemStocksAsync(int itemId)
        {
            return await _inventoryRepository.GetStocksByItemIdAsync(itemId);
        }

        public async Task<IEnumerable<StockDTO>> GetUserStocksAsync(int userId)
        {
            return await _inventoryRepository.GetStocksByUserIdAsync(userId);
        }

        public async Task<StockDTO> AddStockAsync(StockDTO stockDto)
        {
            return await _inventoryRepository.AddStockAsync(stockDto);
        }

        public async Task<StockDTO> UpdateStockAsync(int id, UpdateStockDTO updateStockDto)
        {
            return await _inventoryRepository.UpdateStockAsync(id, updateStockDto);
        }

        public async Task DeleteStockAsync(int id)
        {
            await _inventoryRepository.DeleteStockAsync(id);
        }

        // Category-related methods
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesByUserIdAsync(int userId)
        {
            return await _inventoryRepository.GetCategoriesByUserIdAsync(userId);
        }

        public async Task<CategoryDTO> CreateCategoryAsync(int userId, string categoryName)
        {
            return await _inventoryRepository.CreateCategoryAsync(userId, categoryName);
        }

        public async Task<bool> AssignCategoryToItemAsync(int userId, int itemId, int categoryId)
        {
            return await _inventoryRepository.AssignCategoryToItemAsync(userId, itemId, categoryId);
        }

        public async Task<bool> AssignNewCategoryToItemAsync(int userId, int itemId, string categoryName)
        {
            return await _inventoryRepository.AssignNewCategoryToItemAsync(userId, itemId, categoryName);
        }
    }
}