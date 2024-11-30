using IMS.DTO;
using IMS.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    }

}