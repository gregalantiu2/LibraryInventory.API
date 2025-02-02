using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities.Item
{
    [Table("ItemFineOccurenceType")]
    public class ItemFineOccurenceTypeEntity
    {
        [Key]
        public int ItemFineOccurenceTypeId { get; set; }
        public required string FineOccurenceTypeName { get; set; }
    }
}
