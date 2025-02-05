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
        public required string ItemTitle { get; set; }
        public required string ItemDescription { get; set; }
        public int ItemTypeId { get; set; }
        public string? Location { get; set; }
        public bool IsActive { get; set; }
        public int ItemPolicyId { get; set; }


        // Navigation properties
        [ForeignKey("ItemTypeId")]
        public required ItemTypeEntity ItemType { get; set; }

        [ForeignKey("ItemPolicyId")]
        public ItemPolicyEntity? ItemPolicy { get; set; }

        public ItemBorrowStatusEntity? ItemBorrowStatus { get; set; }
    }
}
