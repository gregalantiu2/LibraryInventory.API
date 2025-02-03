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

        public string? AdditionalProperties { get; set; }


        // Navigation properties
        public ICollection<ItemDetailEntity>? ItemDetail { get; set; }
    }
}