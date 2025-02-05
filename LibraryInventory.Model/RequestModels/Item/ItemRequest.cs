using System.ComponentModel;

namespace LibraryInventory.Model.RequestModels.Item
{
    public class ItemRequest
    {
        [DefaultValue(null)]
        public int? ItemId { get; set; }
        public required string ItemTitle { get; set; }
        public required string ItemDescription { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemPolicyId { get; set; }
        public string? ItemLocation { get; set; }
    }
}
