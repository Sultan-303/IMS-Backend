using IMS.DTO;
using IMS.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.DAL.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IMSContext _context;
        private readonly ILogger<StockRepository> _logger;

        public StockRepository(IMSContext context, ILogger<StockRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Stock>> GetAllStockAsync()
        {
            _logger.LogInformation("Fetching all stock from database");
            var stock = await _context.Stocks.ToListAsync();
            _logger.LogInformation($"Fetched {stock.Count} stock items from database");
            return stock;
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching stock with ID: {id} from database");
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.StockID == id);
            if (stock == null)
            {
                _logger.LogWarning($"Stock with ID {id} not found in database.");
            }
            else
            {
                _logger.LogInformation($"Fetched stock with ID: {id} from database");
            }
            return stock;
        }

        public async Task AddStockAsync(Stock stock)
        {
            _logger.LogInformation($"Adding stock to database: {stock}");
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Added stock with ID: {stock.StockID} to database");
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            _logger.LogInformation($"Updating stock in database: {stock}");
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Updated stock with ID: {stock.StockID} in database");
        }

        public async Task DeleteStockAsync(int id)
        {
            _logger.LogInformation($"Deleting stock with ID: {id} from database");
            var stock = await GetStockByIdAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Deleted stock with ID: {id} from database");
            }
            else
            {
                _logger.LogWarning($"Stock with ID {id} not found in database.");
            }
        }
    }
}