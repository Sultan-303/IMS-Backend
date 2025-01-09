using IMS.BLL.DTOs.ClientDashboard;
using IMS.BLL.Interfaces.Repositories;
using IMS.BLL.Interfaces.Services;

namespace IMS.BLL.Services
{
    public class ClientDashboardService : IClientDashboardService
    {
        private readonly IItemRepository _itemRepository;

        public ClientDashboardService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ClientDashboardStatsDTO> GetClientDashboardStatsAsync(int userId, string? searchQuery = null)
        {
            return await _itemRepository.GetClientDashboardStatsAsync(searchQuery, userId);
        }
    }
}