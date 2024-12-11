using IMS.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStockAsync();
        Task<Stock> GetStockByIdAsync(int id);
        Task AddStockAsync(Stock stock);
        Task UpdateStockAsync(Stock stock);
        Task DeleteStockAsync(int id);
    }
}