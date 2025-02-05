using System.ComponentModel;

namespace LibraryInventory.Model.RequestModels.Item
{
    public class ItemPolicyRequest
    {
        [DefaultValue(null)]
        public int? ItemPolicyId { get; set; }
        public required string ItemPolicyName { get; set; }
        public bool AllowedToCheckout { get; set; }
        public int MaxRenewalsAllowed { get; set; }
        public int CheckoutDays { get; set; }
        public decimal FineAmount { get; set; }
        public int ItemFineOccurenceTypeId { get; set; }
    }
}
