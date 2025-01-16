using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs.Inventory
{
    public class UpdateItemDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(20)]
        public string? Unit { get; set; }

        public string? Description { get; set; }

        [Range(0.01, 10000)]
        public decimal? Price { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}