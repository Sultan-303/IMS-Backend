using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Common.Entities
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [Required]
        [ForeignKey(nameof(Item))]
        public int ItemID { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public virtual Item Item { get; set; }
    }
}