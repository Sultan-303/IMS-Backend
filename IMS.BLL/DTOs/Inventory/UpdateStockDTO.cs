namespace IMS.BLL.DTOs.Inventory
{
    public class UpdateStockDTO
    {
            public required int Id { get; set; }
            public required int ItemId { get; set; }
            public int? NewQuantity { get; set; }
            public DateTime? NewArrivalDate { get; set; }
            public DateTime? NewExpiryDate { get; set; }

            public int UserId { get; set; } // Added
    }
}