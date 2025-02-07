using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Model.RequestModels.Person
{
    public class MemberRequest
    {
        [DefaultValue(null)]
        public string? MemberId { get; set; }
        [Required]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string State { get; set; }
        [Required]
        public required string ZipCode { get; set; }
        [Required]
        public required string Country { get; set; }
    }
}
