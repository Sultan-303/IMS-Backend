using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMSContext _context;

        public ItemRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task AddItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ItemNameExistsAsync(string itemName)
        {
            return await _context.Items.AnyAsync(i => i.ItemName == itemName);
        }

        public async Task UpdateItemAsync(Item item)
        {
            var existingItem = await _context.Items.FindAsync(item.ItemID);
            if (existingItem == null)
            {
                throw new InvalidOperationException("Item not found.");
            }

            _context.Entry(existingItem).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetItemByIdAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasRelatedStocksAsync(int itemId)
        {
            return await _context.Stocks.AnyAsync(s => s.ItemID == itemId);
        }

        public async Task DeleteRelatedStocksAsync(int itemId)
        {
            var relatedStocks = _context.Stocks.Where(s => s.ItemID == itemId);
            _context.Stocks.RemoveRange(relatedStocks);
            await _context.SaveChangesAsync();
        }
    }
}