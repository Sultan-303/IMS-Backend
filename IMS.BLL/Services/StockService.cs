using IMS.BLL.DTOs.Stock;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Interfaces.Services;

namespace IMS.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockDTO>> GetAllStockAsync()
        {
            return await _stockRepository.GetAllStockAsync();
        }

        public async Task<StockDTO> GetStockByIdAsync(int id)
        {
            return await _stockRepository.GetStockByIdAsync(id);
        }

        public async Task AddStockAsync(StockDTO stockDto)
        {
            if (stockDto == null)
                throw new ArgumentNullException(nameof(stockDto));

            await _stockRepository.AddStockAsync(stockDto);
        }

        public async Task UpdateStockAsync(StockDTO stockDto)
        {
            if (stockDto == null)
                throw new ArgumentNullException(nameof(stockDto));

            await _stockRepository.UpdateStockAsync(stockDto);
        }

        public async Task DeleteStockAsync(int id)
        {
            await _stockRepository.DeleteStockAsync(id);
        }
    }
}