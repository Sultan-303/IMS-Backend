using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs.Inventory
{
    public class ItemDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}