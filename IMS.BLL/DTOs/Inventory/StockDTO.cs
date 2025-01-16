using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs.Inventory
{
    public class StockDTO
    {
        public int StockID { get; set; }

        [Required]
        public int ItemID { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int MinimumStockQuantity { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        public int UserId { get; set; } // Added
    }
}