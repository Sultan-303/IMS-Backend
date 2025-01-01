using AutoMapper;
using IMS.DAL.Entities;
using IMS.BLL.DTOs.Stock;
using IMS.BLL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IMS.DAL.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IMSContext _context;
        private readonly IMapper _mapper;

        public StockRepository(IMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDTO>> GetAllStockAsync()
        {
            var stocks = await _context.Stocks.Include(s => s.Item).ToListAsync();
            return _mapper.Map<IEnumerable<StockDTO>>(stocks);
        }

        public async Task<StockDTO> GetStockByIdAsync(int id)
        {
            var stock = await _context.Stocks
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.StockID == id);
            return _mapper.Map<StockDTO>(stock);
        }

        public async Task AddStockAsync(StockDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(StockDTO stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
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
            var stock = await _context.Stocks.FindAsync(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
            }
        }
    }
}