using LibraryInventory.Data.Entities.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("Transaction")]
    public class TransactionEntity : BaseEntity
    {
        [Key]
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? ItemId { get; set; }
        public int? MemberId { get; set; }


        // Navigation properties
        [ForeignKey("TransactionTypeId")]
        public required TransactionTypeEntity TransactionType { get; set; }

        [ForeignKey("ItemId")]
        public ItemEntity? Item { get; set; }

        [ForeignKey("MemberId")]
        public MemberEntity? Member { get; set; }

        public IEnumerable<TransactionPaymentEntity>? TransactionPayments { get; set; }
    }
}