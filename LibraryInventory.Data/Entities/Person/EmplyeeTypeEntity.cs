using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities.Person
{
    [Table("EmployeeType")]
    public class EmployeeTypeEntity : BaseEntity
    {
        [Key]
        public int EmployeeTypeId { get; set; }
        
        [MaxLength(25)]
        public required string EmployeeTypeName { get; set; }

        // Navigation properties
        public ICollection<EmployeeEntity>? Employee { get; set; }
    }
}