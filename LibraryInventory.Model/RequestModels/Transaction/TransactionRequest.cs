using System.ComponentModel;

namespace LibraryInventory.Model.RequestModels.Transaction
{
    public class TransactionRequest
    {
        [DefaultValue(null)]
        public int? TransactionId { get; set; }
        public string MemberId { get; set; }
        public int ItemId { get; set; }
    }
}
