using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities.Item
{
    [Table("ItemFineOccurenceType")]
    public class ItemFineOccurenceTypeEntity : BaseEntity
    {
        [Key]
        public int ItemFineOccurenceTypeId { get; set; }
        public required string FineOccurenceTypeName { get; set; }
    }
}
