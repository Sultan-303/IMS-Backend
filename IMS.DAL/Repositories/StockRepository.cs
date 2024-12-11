using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DAL.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IMSContext _context;

        public StockRepository(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllStockAsync()
        {
            return await _context.Stocks.Include(s => s.Item).ToListAsync();
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Item).FirstOrDefaultAsync(s => s.StockID == id);
        }

        public async Task AddStockAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            var existingStock = await _context.Stocks.FindAsync(stock.StockID);
            if (existingStock == null)
            {
                throw new InvalidOperationException("Stock not found.");
            }

            _context.Entry(existingStock).CurrentValues.SetValues(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStockAsync(int id)
        {
            var stock = await GetStockByIdAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
    }
}