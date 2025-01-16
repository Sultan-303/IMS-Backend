using IMS.BLL.DTOs.Inventory;
using IMS.DAL.Entities;
using IMS.BLL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace IMS.DAL.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSContext _context;
        private readonly IMapper _mapper;

        public InventoryRepository(IMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Item-related methods
        public async Task<IEnumerable<ItemDTO>> GetItemsByUserIdAsync(int userId)
        {
            var items = await _context.Items
                                      .Where(i => i.UserId == userId)
                                      .ToListAsync();

            return _mapper.Map<IEnumerable<ItemDTO>>(items);
        }

        public async Task<ItemDTO> AddItemAsync(int userId, ItemDTO itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            item.UserId = userId;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<ItemDTO> UpdateItemAsync(int id, UpdateItemDTO updateItemDto)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return null;

            _mapper.Map(updateItemDto, item);
            _context.Items.Update(item);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDTO>(item);
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                var associatedStocks = _context.Stocks.Where(s => s.ItemID == id);
                if (associatedStocks.Any())
                {
                    _context.Stocks.RemoveRange(associatedStocks);
                }
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        // Stock-related methods
        public async Task<IEnumerable<StockDTO>> GetStocksByItemIdAsync(int itemId)
        {
            var stocks = await _context.Stocks
                                       .Where(s => s.ItemID == itemId)
                                       .ToListAsync();

            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<IEnumerable<StockDTO>> GetStocksByUserIdAsync(int userId)
        {
            var stocks = await _context.Stocks
                                    .Include(s => s.Item)
                                    .Where(s => s.Item.UserId == userId)
                                    .ToListAsync();

            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO> AddStockAsync(StockDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return _mapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO> UpdateStockAsync(int id, UpdateStockDTO updateStockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
                return null;

            _mapper.Map(updateStockDto, stock);
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();

            return _mapper.Map<StockDTO>(stock);
        }

        public async Task DeleteStockAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }

        // Category-related methods
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesByUserIdAsync(int userId)
        {
            var categories = await _context.Categories
                                           .Where(c => c.UserId == userId)
                                           .ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> CreateCategoryAsync(int userId, string categoryName)
        {
            // Check if the category already exists for the user
            var existingCategory = await _context.Categories
                                                .FirstOrDefaultAsync(c => c.UserId == userId && 
                                                    c.CategoryName.ToLower() == categoryName.ToLower());

            if (existingCategory != null)
            {
                // Category already exists
                return null;
            }

            var category = new Category
            {
                CategoryName = categoryName,
                UserId = userId
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> AssignCategoryToItemAsync(int userId, int itemId, int categoryId)
        {
            var category = await _context.Categories
                                         .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);
            if (category == null)
                return false;

            var item = await _context.Items
                                     .FirstOrDefaultAsync(i => i.ItemID == itemId && i.UserId == userId);
            if (item == null)
                return false;

            // Check if the association already exists
            var existingAssociation = await _context.ItemCategories
                                                    .FirstOrDefaultAsync(ic => ic.ItemID == itemId && ic.CategoryID == categoryId);
            if (existingAssociation != null)
                return false;

            var itemCategory = new ItemCategory
            {
                ItemID = itemId,
                CategoryID = categoryId
            };

            _context.ItemCategories.Add(itemCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignNewCategoryToItemAsync(int userId, int itemId, string categoryName)
        {
            var item = await _context.Items
                                     .FirstOrDefaultAsync(i => i.ItemID == itemId && i.UserId == userId);
            if (item == null)
                return false;

            // Check if the category already exists
            var category = await _context.Categories
                                         .FirstOrDefaultAsync(c => c.UserId == userId && 
                                             c.CategoryName.ToLower() == categoryName.ToLower());

            if (category == null)
            {
                // Create the new category
                category = new Category
                {
                    CategoryName = categoryName,
                    UserId = userId
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }

            // Check if the association already exists
            var existingAssociation = await _context.ItemCategories
                                                    .FirstOrDefaultAsync(ic => ic.ItemID == itemId && ic.CategoryID == category.Id);
            if (existingAssociation != null)
                return false;

            var itemCategory = new ItemCategory
            {
                ItemID = itemId,
                CategoryID = category.Id
            };

            _context.ItemCategories.Add(itemCategory);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}