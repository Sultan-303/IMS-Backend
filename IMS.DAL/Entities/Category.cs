using System.ComponentModel.DataAnnotations;

namespace IMS.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; } // Ensure this property exists

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<ItemCategory> ItemCategory { get; set; }
    }
}