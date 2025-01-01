using IMS.BLL.DTOs.Item;

namespace IMS.BLL.Interfaces.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
        Task<ItemDTO> GetItemByIdAsync(int id);
        Task AddItemAsync(ItemDTO itemDto);
        Task UpdateItemAsync(ItemDTO itemDto);
        Task DeleteItemAsync(int id);
        Task<bool> HasRelatedStocksAsync(int itemId);
        Task DeleteRelatedStocksAsync(int itemId);
    }
}