// Item.cs
namespace IMS.DTO
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}