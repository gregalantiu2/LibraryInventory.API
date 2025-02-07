using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryInventory.Model.RequestModels.Item
{
    public class ItemRequest
    {
        [DefaultValue(null)]
        public int? ItemId { get; set; }
        [Required]
        public required string ItemTitle { get; set; }
        [Required]
        public required string ItemDescription { get; set; }
        [Required]
        public int ItemTypeId { get; set; }
        public int? ItemPolicyId { get; set; }
        public string? ItemLocation { get; set; }
    }
}
