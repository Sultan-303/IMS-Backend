using IMS.DTO;
using IMS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            try
            {
                return await _context.Items.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your actual logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                return await _context.Items.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddItemAsync(Item item)
        {
            try
            {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ItemNameExistsAsync(string itemName)
        {
            try
            {
                return await _context.Items.AnyAsync(i => i.ItemName == itemName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateItemAsync(Item item)
        {
            try
            {
                var existingItem = await _context.Items.FindAsync(item.ItemID);
                if (existingItem == null)
                {
                    throw new InvalidOperationException("Item not found.");
                }

                _context.Entry(existingItem).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            try
            {
                var item = await GetItemByIdAsync(id);
                if (item != null)
                {
                    _context.Items.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> HasRelatedStocksAsync(int itemId)
        {
            try
            {
                return await _context.Stocks.AnyAsync(s => s.ItemID == itemId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRelatedStocksAsync(int itemId)
        {
            try
            {
                var relatedStocks = _context.Stocks.Where(s => s.ItemID == itemId);
                _context.Stocks.RemoveRange(relatedStocks);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
