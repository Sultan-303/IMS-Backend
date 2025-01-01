namespace IMS.BLL.DTOs.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}