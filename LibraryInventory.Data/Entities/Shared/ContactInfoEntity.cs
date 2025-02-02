using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities.Shared
{
    [Table("ContactInfo")]
    public class ContactInfoEntity
    {
        [Key]
        public int ContactInfoId { get; set; }
   
        [MaxLength(20)]
        public required string PhoneNumber { get; set; }
        
        [MaxLength(255)]
        public required string Email { get; set; }
        
        [MaxLength(100)]
        public required string Street { get; set; }
        
        [MaxLength(50)]
        public required string City { get; set; }
        
        [MaxLength(2)]
        public required string State { get; set; }
        
        [MaxLength(10)]
        public required string ZipCode { get; set; }
        
        [MaxLength(50)]
        public required string Country { get; set; }
    }
}