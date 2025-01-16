using IMS.BLL.DTOs.Inventory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.BLL.Interfaces.Services
{
    public interface IInventoryService
    {
        // Item-related methods
        Task<IEnumerable<ItemDTO>> GetUserItemsAsync(int userId);
        Task<ItemDTO> AddItemAsync(int userId, ItemDTO itemDto);
        Task<ItemDTO> UpdateItemAsync(int id, UpdateItemDTO updateItemDto);
        Task DeleteItemAsync(int id);

        // Stock-related methods
        Task<IEnumerable<StockDTO>> GetItemStocksAsync(int itemId);
        Task<IEnumerable<StockDTO>> GetUserStocksAsync(int userId);
        Task<StockDTO> AddStockAsync(StockDTO stockDto);
        Task<StockDTO> UpdateStockAsync(int id, UpdateStockDTO updateStockDto);
        Task DeleteStockAsync(int id);

        
        Task<bool> AssignCategoryToItemAsync(int userId, int itemId, int categoryId);
        Task<bool> AssignNewCategoryToItemAsync(int userId, int itemId, string categoryName);
        Task<IEnumerable<CategoryDTO>> GetCategoriesByUserIdAsync(int userId);
        Task<CategoryDTO> CreateCategoryAsync(int userId, string categoryName);

    }
}