using System;
using System.Collections.Generic;

namespace IMS.DAL.Entities
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int MinimumStockQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }

        // New Properties
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }  // Navigation Property

        public ICollection<Stock> Stocks { get; set; }
        public ICollection<ItemCategory> ItemCategories { get; set; }
    }
}