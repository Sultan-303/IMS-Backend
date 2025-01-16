using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.DAL.Entities
{
    public class ItemCategory
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}