using IMS.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockModel>> GetAllStockAsync();
        Task<StockModel> GetStockByIdAsync(int id);
        Task AddStockAsync(StockModel stock);
        Task UpdateStockAsync(StockModel stock);
        Task DeleteStockAsync(int id);
    }
}