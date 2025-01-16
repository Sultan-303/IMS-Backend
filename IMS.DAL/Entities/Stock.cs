using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.DAL.Entities
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [Required]
        [ForeignKey(nameof(Item))]
        public int ItemID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Added

        public virtual Item Item { get; set; }
        public virtual User User { get; set; } // Added
    }
}