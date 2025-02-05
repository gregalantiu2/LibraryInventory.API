using LibraryInventory.Data.Entities.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemType")]
    public class ItemTypeEntity : BaseEntity
    {
        [Key]
        public int ItemTypeId { get; set; }
        
        [MaxLength(25)]
        public required string ItemTypeName { get; set; }


        // Navigation properties
        public ICollection<ItemEntity>? Item { get; set; }
        public ICollection<ItemTypeProperties>? ItemTypeProperties { get; set; }
    }
}