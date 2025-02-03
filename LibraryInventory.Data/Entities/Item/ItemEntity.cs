using LibraryInventory.Data.Entities.Item;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryInventory.Data.Entities
{
    [Table("Item")]
    public class ItemEntity : BaseEntity
    {
        [Key]
        public int ItemId { get; set; }

        public string? Location { get; set; }

        public bool IsActive { get; set; }

        public int ItemPolicyId { get; set; }

        public int ItemDetailId { get; set; }

        public int ItemBorrowStatusId { get; set; }


        // Navigation properties
        [ForeignKey("ItemDetailId")]
        public ItemDetailEntity? ItemDetail { get; set; }

        [ForeignKey("ItemPolicyId")]
        public ItemPolicyEntity? ItemPolicy { get; set; }

        [ForeignKey("ItemBorrowStatusId")]
        public ItemBorrowStatusEntity? ItemBorrowStatus { get; set; }
    }
}
