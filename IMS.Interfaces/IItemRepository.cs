using IMS.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(int id);
        Task<bool> ItemNameExistsAsync(string itemName);
    }
}