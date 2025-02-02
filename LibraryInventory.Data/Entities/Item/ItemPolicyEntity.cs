using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemPolicy")]
    public class ItemPolicyEntity
    {
        [Key]
        public int ItemPolicyId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }
        public bool AllowedToCheckout { get; set; }
        public int MaxRenewalsAllowed { get; set; }
        public int CheckoutDays { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FineAmount { get; set; }
        public int FineOccurrence { get; set; }
        public int ItemId { get; set; }

        // Navigation properties
        [ForeignKey("ItemId")]

        public ItemEntity Item { get; set; }
    }
}