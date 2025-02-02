using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("TransactionPaymentType")]
    public class TransactionPaymentTypeEntity
    {
        [Key]
        public int TransactionPaymentTypeId { get; set; }
        public required string TransactionPaymentTypeName { get; set; }
    }
}