using LibraryInventory.Data.Entities.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemBorrowStatus")]
    public class ItemBorrowStatusEntity : BaseEntity
    {
        [Key]
        public int ItemBorrowStatusId { get; set; }
        public DateTime? CheckedOutDate { get; set; }
        public DateTime? DueBack { get; set; }
        public int RenewedCount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FineAmountAccrued { get; set; }
        public int ItemId { get; set; }
        public int MemberKeyId { get; set; }


        // Navigation properties
        [ForeignKey("ItemId")]
        public ItemEntity? Item { get; set; }

        [ForeignKey("MemberKeyId")]
        public MemberEntity? Member { get; set; }
    }
}
