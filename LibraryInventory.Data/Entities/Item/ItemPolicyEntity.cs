using LibraryInventory.Data.Entities.Item;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryInventory.Data.Entities
{
    [Table("ItemPolicy")]
    public class ItemPolicyEntity : BaseEntity
    {
        [Key]
        public int ItemPolicyId { get; set; }

        [MaxLength(50)]
        public required string ItemPolicyName { get; set; }
        public bool AllowedToCheckout { get; set; }
        public int MaxRenewalsAllowed { get; set; }
        public int CheckoutDays { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FineAmount { get; set; }
        public int ItemFineOccurenceTypeId { get; set; }


        // Navigation properties
        [ForeignKey("ItemFineOccurenceTypeId")]
        public required ItemFineOccurenceTypeEntity ItemFineOccurenceType { get; set; }
        public ICollection<ItemEntity>? Item { get; set; }
    }
}