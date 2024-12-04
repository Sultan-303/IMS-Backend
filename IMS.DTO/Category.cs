namespace IMS.DTO
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}