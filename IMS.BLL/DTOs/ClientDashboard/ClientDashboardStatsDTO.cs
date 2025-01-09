// File: IMS.BLL.DTOs.ClientDashboard/ClientDashboardStatsDTO.cs

namespace IMS.BLL.DTOs.ClientDashboard
{
    public class ClientDashboardStatsDTO
    {
        public int LowStockItemsCount { get; set; }
        public int NearExpiryItemsCount { get; set; }
        public int NewItemsCount { get; set; }
        public List<LowStockItemDTO> LowStockItems { get; set; }
        public List<NearExpiryItemDTO> NearExpiryItems { get; set; }
    }

    public class LowStockItemDTO
    {
        public int Id { get; set; } // Added
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public string Category { get; set; }
    }

    public class NearExpiryItemDTO
    {
        public int Id { get; set; } // Added
        public string ProductName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Category { get; set; }
    }
}