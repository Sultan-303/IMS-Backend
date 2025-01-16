using System;
using System.Collections.Generic;

namespace IMS.DAL.Entities
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }  // Navigation Property

        public ICollection<Stock> Stocks { get; set; }
        public ICollection<ItemCategory> ItemCategory { get; set; }
    }
}