using IMS.BLL.DTOs.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.BLL.Interfaces.Repositories
{
    public interface IInventoryRepository
    {
        // Item-related methods
        Task<IEnumerable<ItemDTO>> GetItemsByUserIdAsync(int userId);
        Task<ItemDTO> AddItemAsync(int userId, ItemDTO itemDto);
        Task<ItemDTO> UpdateItemAsync(int id, UpdateItemDTO updateItemDto);
        Task DeleteItemAsync(int id);

        // Stock-related methods
        Task<IEnumerable<StockDTO>> GetStocksByItemIdAsync(int itemId);
        Task<IEnumerable<StockDTO>> GetStocksByUserIdAsync(int userId);
        Task<StockDTO> AddStockAsync(StockDTO stockDto);
        Task<StockDTO> UpdateStockAsync(int id, UpdateStockDTO updateStockDto);
        Task DeleteStockAsync(int id);

        // Category-related methods
        Task<IEnumerable<CategoryDTO>> GetCategoriesByUserIdAsync(int userId);
        Task<CategoryDTO> CreateCategoryAsync(int userId, string categoryName);
        Task<bool> AssignCategoryToItemAsync(int userId, int itemId, int categoryId);
        Task<bool> AssignNewCategoryToItemAsync(int userId, int itemId, string categoryName);
    }
}