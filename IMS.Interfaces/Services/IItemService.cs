using IMS.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> GetAllItemsAsync();
        Task<ItemModel> GetItemByIdAsync(int id);
        Task AddItemAsync(ItemModel item);
        Task UpdateItemAsync(ItemModel item);
        Task DeleteItemAsync(int id);
        Task<bool> HasRelatedStocksAsync(int ItemID); // Existing method
        Task DeleteRelatedStocksAsync(int ItemID); // New method
    }
}
