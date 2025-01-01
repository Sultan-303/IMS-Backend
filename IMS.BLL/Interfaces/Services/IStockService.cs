using IMS.BLL.DTOs.Stock;

namespace IMS.BLL.Interfaces.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockDTO>> GetAllStockAsync();
        Task<StockDTO> GetStockByIdAsync(int id);
        Task AddStockAsync(StockDTO stockDto);
        Task UpdateStockAsync(StockDTO stockDto);
        Task DeleteStockAsync(int id);
    }
}