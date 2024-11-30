using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DTO;

namespace IMS.Interfaces
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
