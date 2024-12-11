using IMS.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
        Task<bool> ItemNameExistsAsync(string ItemName);
        Task<bool> HasRelatedStocksAsync(int ItemID); // New method
        Task DeleteRelatedStocksAsync(int ItemID); // New method
    }
}
