namespace IMS.Common.Models
{
    public class StockModel
    {
        public int StockID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}