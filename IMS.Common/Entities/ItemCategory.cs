using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Common.Entities
{
    public class ItemCategory
    {
        [ForeignKey("Item")]
        public int ItemID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Item Item { get; set; }
        public Category Category { get; set; }
    }
}