using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs.Inventory
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
    }
}