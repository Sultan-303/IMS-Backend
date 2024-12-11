using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IMSContext _context;

        public CategoriesRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id) ?? throw new KeyNotFoundException($"Category with id {id} not found.");
            return category;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Set<IMS.Common.Entities.Category>().AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Set<IMS.Common.Entities.Category>().Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}