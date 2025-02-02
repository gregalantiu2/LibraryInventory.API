using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemBorrowStatus")]
    public class ItemBorrowStatusEntity
    {
        [Key]
        public int ItemBorrowStatusId { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime? CheckedOutDate { get; set; }
        public DateTime? DueBack { get; set; }
        public int RenewedCount { get; set; }
        public int ItemId { get; set; }

        // Navigation properties
        [ForeignKey("ItemId")]
        [InverseProperty("ItemBorrowStatus")]
        public ItemEntity? Item { get; set; }
    }
}
