using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("TransactionType")]
    public class TransactionTypeEntity
    {
        [Key]
        public int TransactionTypeId { get; set; }
        public required string TransactionTypeName { get; set; }
    }
}