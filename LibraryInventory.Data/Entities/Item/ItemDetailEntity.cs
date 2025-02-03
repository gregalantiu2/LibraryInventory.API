using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities.Item
{
    [Table("ItemDetail")]
    public class ItemDetailEntity : BaseEntity
    {
        [Key]
        public int ItemDetailId { get; set; }
        public required string ItemTitle { get; set; }
        public required string ItemDescription { get; set; }
        public int ItemTypeId { get; set; }


        // Navigation properties
        [ForeignKey("ItemTypeId")]
        public required ItemTypeEntity ItemType { get; set; }
        public ICollection<ItemEntity>? Item { get; set; }
    }
}