using IMS.DTO;
using IMS.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly ILogger<StockService> _logger;

        public StockService(IStockRepository stockRepository, ILogger<StockService> logger)
        {
            _stockRepository = stockRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Stock>> GetAllStockAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all stock from repository");
                var stock = await _stockRepository.GetAllStockAsync();
                _logger.LogInformation($"Fetched {stock.Count()} stock items from repository");
                return stock;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllStockAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching stock with ID: {id} from repository");
                var stock = await _stockRepository.GetStockByIdAsync(id);
                if (stock == null)
                {
                    _logger.LogWarning($"Stock with ID {id} not found in repository.");
                }
                else
                {
                    _logger.LogInformation($"Fetched stock with ID: {id} from repository");
                }
                return stock;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetStockByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task AddStockAsync(Stock stock)
        {
            if (stock == null)
            {
                _logger.LogWarning("Received null stock object");
                throw new ArgumentNullException(nameof(stock), "Stock is null.");
            }

            try
            {
                _logger.LogInformation($"Adding stock to repository: {stock}");
                await _stockRepository.AddStockAsync(stock);
                _logger.LogInformation($"Added stock with ID: {stock.StockID} to repository");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in AddStockAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateStockAsync(Stock stock)
        {
            if (stock == null)
            {
                _logger.LogWarning("Received null stock object");
                throw new ArgumentNullException(nameof(stock), "Stock is null.");
            }

            try
            {
                _logger.LogInformation($"Updating stock in repository: {stock}");
                await _stockRepository.UpdateStockAsync(stock);
                _logger.LogInformation($"Updated stock with ID: {stock.StockID} in repository");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateStockAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteStockAsync(int id)
{
    try
    {
        var stock = await _stockRepository.GetStockByIdAsync(id);
        if (stock == null)
        {
            _logger.LogWarning($"Stock with ID {id} not found in repository.");
            return; // Ensure no further action is taken if stock is not found
        }
        await _stockRepository.DeleteStockAsync(id);
        _logger.LogInformation($"Deleted stock with ID: {id} from repository");
    }
    catch (Exception ex)
    {
        _logger.LogError($"Error in DeleteStockAsync: {ex.Message}");
        throw;
    }
}
    }
}