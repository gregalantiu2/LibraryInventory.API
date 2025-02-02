using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities.Item
{
    [Table("ItemDetail")]
    public class ItemDetailEntity
    {
        [Key]
        public int ItemDetailId { get; set; }

        public required string ItemTitle { get; set; }

        public required string ItemDescription { get; set; }

        public int ItemId { get; set; }

        public int ItemTypeId { get; set; }


        // Navigation properties
        [ForeignKey("ItemTypeId")]
        public ItemTypeEntity ItemType { get; set; }

        [ForeignKey("ItemId")]
        public ItemEntity Item { get; set; }
    }
}