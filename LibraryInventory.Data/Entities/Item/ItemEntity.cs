using LibraryInventory.Data.Entities.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities
{
    [Table("Item")]
    public class ItemEntity
    {
        [Key]
        public int ItemId { get; set; }

        public string? Location { get; set; }

        public bool IsActive { get; set; }


        // Navigation properties
        public ItemDetailEntity? ItemDetail { get; set; }
        public ItemPolicyEntity? ItemPolicy { get; set; }
        public ItemBorrowStatusEntity? ItemBorrowStatus { get; set; }
    }
}
