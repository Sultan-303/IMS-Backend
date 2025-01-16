using System.ComponentModel.DataAnnotations;

namespace IMS.BLL.DTOs.Inventory
{
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string CategoryName { get; set; }
    }
}