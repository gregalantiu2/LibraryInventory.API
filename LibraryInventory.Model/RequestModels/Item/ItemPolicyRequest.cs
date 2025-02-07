using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Model.RequestModels.Item
{
    public class ItemPolicyRequest
    {
        [DefaultValue(null)]
        public int? ItemPolicyId { get; set; }
        [Required]
        public required string ItemPolicyName { get; set; }
        [Required]
        public bool AllowedToCheckout { get; set; }
        [Required]
        public int MaxRenewalsAllowed { get; set; }
        [Required]
        public int CheckoutDays { get; set; }
        [Required]
        public decimal FineAmount { get; set; }
        [Required]
        public int ItemFineOccurenceTypeId { get; set; }
    }
}
