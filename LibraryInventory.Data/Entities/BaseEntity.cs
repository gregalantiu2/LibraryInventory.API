using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Entities
{
    public class BaseEntity
    {
        [MaxLength(150)]
        public required string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength(150)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
