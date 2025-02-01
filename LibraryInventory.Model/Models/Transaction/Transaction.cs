using LibraryInventory.Model.Enums;

namespace LibraryInventory.Model.Models.Transaction
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
