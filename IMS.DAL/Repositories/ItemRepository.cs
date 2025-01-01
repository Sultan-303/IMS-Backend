using AutoMapper;
using IMS.DAL.Entities;
using IMS.BLL.DTOs.Item;
using IMS.BLL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMSContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(IMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
        {
            var items = await _context.Items.ToListAsync();
            return _mapper.Map<IEnumerable<ItemDTO>>(items);
        }

        public async Task<ItemDTO> GetItemByIdAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return _mapper.Map<ItemDTO>(item);
        }

        public async Task AddItemAsync(ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ItemNameExistsAsync(string itemName)
        {
            return await _context.Items.AnyAsync(i => i.ItemName == itemName);
        }

        public async Task UpdateItemAsync(ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
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
            var item = await _context.Items.FindAsync(id);
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