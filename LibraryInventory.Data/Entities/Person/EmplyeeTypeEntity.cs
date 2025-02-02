using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities.Person
{
    [Table("EmployeeType")]
    public class EmployeeTypeEntity
    {
        [Key]
        public int EmployeeTypeId { get; set; }
        
        [MaxLength(50)]
        public required string EmployeeTypeName { get; set; }
    }
}