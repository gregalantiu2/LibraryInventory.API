using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryInventory.Data.Entities.Shared;

namespace LibraryInventory.Data.Entities.Person
{
    [Table("Employee")]
    public class EmployeeEntity : BaseEntity
    {
        [Key]
        public int EmployeeKeyId { get; set; }

        [MaxLength(50)]
        public string? EmployeeId { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public required string LastName { get; set; }
        public bool Active { get; set; }
        public int ContactInfoId { get; set; }
        public int EmployeeTypeId { get; set; }


        // Navigation properties
        [ForeignKey("ContactInfoId")]
        public required ContactInfoEntity ContactInfo { get; set; }

        [ForeignKey("EmployeeTypeId")]
        public required EmployeeTypeEntity EmployeeType { get; set; }
    }
}