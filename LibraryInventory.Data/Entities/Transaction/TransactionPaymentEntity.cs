using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("TransactionPayment")]
    public class TransactionPaymentEntity : BaseEntity
    {
        [Key]
        public int TransactionPaymentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaymentAmount { get; set; }

        public int TransactionPaymentTypeId { get; set; }


        // Navigation properties
        [ForeignKey("TransactionPaymentTypeId")]
        public required TransactionPaymentTypeEntity TransactionPaymentType { get; set; }

        [ForeignKey("TransactionId")]
        public required TransactionEntity Transaction { get; set; }
    }
}