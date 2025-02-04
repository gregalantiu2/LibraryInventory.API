using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibraryInventory.Data.Entities.Shared;

namespace LibraryInventory.Data.Entities.Person
{
    [Table("Member")]
    public class MemberEntity : BaseEntity
    {
        [Key]
        public int MemberKeyId { get; set; }

        [MaxLength(50)]
        public string? MemberId { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public required string LastName { get; set; }

        public int ContactInfoId { get; set; }

        public int ItemsBorrowed { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FineAmountOwed { get; set; }
        public bool Active { get; set; }


        // Navigation properties
        [ForeignKey("ContactInfoId")]
        public required ContactInfoEntity ContactInfo { get; set; }
    }
}