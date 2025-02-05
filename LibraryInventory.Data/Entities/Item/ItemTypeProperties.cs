using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities.Item
{
    public class ItemTypeProperties
    {
        [Key]
        public int ItemTypePropertyId { get; set; }
        public int ItemTypeId { get; set; }
        public required string PropertyKey { get; set; }
        public required string PropertyValue { get; set; }

        // Navigation properties
        [ForeignKey("ItemTypeId")]
        public ItemTypeEntity ItemType { get; set; }
    }
}
