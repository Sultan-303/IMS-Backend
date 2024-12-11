using IMS.Common.Models;
using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using IMS.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace IMS.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockModel>> GetAllStockAsync()
        {
            var stocks = await _stockRepository.GetAllStockAsync();
            return stocks.Select(ToStockModel);
        }

        public async Task<StockModel> GetStockByIdAsync(int id)
        {
            var stock = await _stockRepository.GetStockByIdAsync(id);
            return stock == null ? null : ToStockModel(stock);
        }

        public async Task AddStockAsync(StockModel stockModel)
        {
            if (stockModel == null)
            {
                throw new ArgumentNullException(nameof(stockModel), "Stock is null.");
            }

            var stock = ToStockEntity(stockModel);
            await _stockRepository.AddStockAsync(stock);
        }

        public async Task UpdateStockAsync(StockModel stockModel)
        {
            if (stockModel == null)
            {
                throw new ArgumentNullException(nameof(stockModel), "Stock is null.");
            }

            var stock = ToStockEntity(stockModel);
            await _stockRepository.UpdateStockAsync(stock);
        }

        public async Task DeleteStockAsync(int id)
        {
            var stock = await _stockRepository.GetStockByIdAsync(id);
            if (stock == null)
            {
                return; // Do nothing if the stock is not found
            }

            await _stockRepository.DeleteStockAsync(id);
        }

        private StockModel ToStockModel(Stock stock)
        {
            return new StockModel
            {
                StockID = stock.StockID,
                ItemID = stock.ItemID,
                Quantity = stock.QuantityInStock,
                ArrivalDate = stock.ArrivalDate,
                ExpiryDate = stock.ExpiryDate ?? DateTime.MinValue
            };
        }

        private Stock ToStockEntity(StockModel stockModel)
        {
            return new Stock
            {
                StockID = stockModel.StockID,
                ItemID = stockModel.ItemID,
                QuantityInStock = stockModel.Quantity,
                ArrivalDate = stockModel.ArrivalDate,
                ExpiryDate = stockModel.ExpiryDate
            };
        }
    }
}