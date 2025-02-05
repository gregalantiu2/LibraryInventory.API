using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.RequestModels
{
    public class ItemRequest
    {
        public int? ItemId { get; set; }
        public required string ItemTitle { get; set; }
        public required string ItemDescription { get; set; }
        public int? ItemDetailId { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemPolicyId { get; set; }
        public string? ItemLocation { get; set; }
    }
}
