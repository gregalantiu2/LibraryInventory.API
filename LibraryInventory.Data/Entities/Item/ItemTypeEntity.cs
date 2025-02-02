using LibraryInventory.Data.Entities.Item;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemType")]
    public class ItemTypeEntity : BaseEntity
    {
        [Key]
        public int ItemTypeId { get; set; }

        public required string Name { get; set; }

        public string? AdditionalProperties { get; set; }


        // Navigation properties
        public ItemDetailEntity? ItemDetail { get; set; }
    }
}