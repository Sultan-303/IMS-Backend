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
                _logger.LogInformation("Fetched {StockCount} stock items from repository", stock.Count());
                return stock ?? new List<Stock>(); // null check
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStockAsync");
                throw new InvalidOperationException("An error occurred while fetching all stock.", ex);
            }
        }

        public async Task<Stock> GetStockByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching stock with ID: {StockId} from repository", id);
                var stock = await _stockRepository.GetStockByIdAsync(id);
                if (stock == null)
                {
                    _logger.LogWarning("Stock with ID {StockId} not found in repository.", id);
                }
                else
                {
                    _logger.LogInformation("Fetched stock with ID: {StockId} from repository", id);
                }
                return stock;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStockByIdAsync");
                throw new InvalidOperationException($"An error occurred while fetching stock with ID {id}.", ex);
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
                _logger.LogInformation("Adding stock to repository: {@Stock}", stock);
                await _stockRepository.AddStockAsync(stock);
                _logger.LogInformation("Added stock with ID: {StockID} to repository", stock.StockID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddStockAsync");
                throw new InvalidOperationException("An error occurred while adding stock.", ex);
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
                _logger.LogInformation("Updating stock in repository: {@Stock}", stock);
                await _stockRepository.UpdateStockAsync(stock);
                _logger.LogInformation("Updated stock with ID: {StockID} in repository", stock.StockID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateStockAsync");
                throw new InvalidOperationException("An error occurred while updating stock.", ex);
            }
        }

        public async Task DeleteStockAsync(int id)
{
    try
    {
        var stock = await _stockRepository.GetStockByIdAsync(id);
        if (stock == null)
        {
            _logger.LogWarning("Stock with ID {StockId} not found in repository.", id);
            return; // stop if no stock is found
        }
        await _stockRepository.DeleteStockAsync(id);
        _logger.LogInformation("Deleted stock with ID: {StockId} from repository", id);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error in DeleteStockAsync");
        throw new InvalidOperationException($"An error occurred while deleting stock with ID {id}.", ex);
    }
}
    }
}