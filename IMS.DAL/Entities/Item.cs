using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMS.DAL.Entities
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public string ItemName { get; set; }

        public string Unit { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<ItemCategory> ItemCategories { get; set; }
    }
}