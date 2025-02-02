using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("TransactionPaymentType")]
    public class TransactionPaymentTypeEntity : BaseEntity
    {
        [Key]
        public int TransactionPaymentTypeId { get; set; }
        [MaxLength(25)]
        public required string TransactionPaymentTypeName { get; set; }
    }
}