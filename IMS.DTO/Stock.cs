using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.DTO
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [ForeignKey("Item")]
        public int ItemID { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}