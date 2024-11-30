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
            catch (Exception)
            {
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
                _context.Items.Update(item);
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
    }
}