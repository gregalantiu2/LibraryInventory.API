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
        [Required(ErrorMessage = "ItemTitle is required.")]
        public required string ItemTitle { get; set; }
        [Required(ErrorMessage = "ItemDescription is required.")]
        public required string ItemDescription { get; set; }
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }

        // Navigation properties
        [ForeignKey("ItemTypeId")]
        [InverseProperty("ItemDetail")]
        public ItemTypeEntity ItemType { get; set; }

        [ForeignKey("ItemId")]
        [InverseProperty("ItemDetail")]
        public ItemEntity Item { get; set; }
    }
}