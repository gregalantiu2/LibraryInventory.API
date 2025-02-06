namespace LibraryInventory.Model.TransactionModels
{
    public class Transaction
    {
        private readonly int? _transactionId;
        private TransactionType _transactionType;
        private DateTime _transactionDate;
        private IEnumerable<TransactionPayment>? _transactionPayments;
        private int? _itemId;
        private string? _memberId;

        public Transaction(TransactionType transactionType
                            ,DateTime transactionDate
                            ,int? itemId
                            ,IEnumerable<TransactionPayment>? transactionPayments = null
                            ,string? memberId = null
                            ,int? transactionId = null)
        {
            _transactionType = transactionType;
            _transactionDate = transactionDate;
            _transactionPayments = transactionPayments;
            _itemId = itemId;
            _memberId = memberId;
            _transactionId = transactionId;
        }

        public int? TransactionId
        {
            get { return _transactionId; }
        }
        public TransactionType TransactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; }
        }
        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }
        public IEnumerable<TransactionPayment>? TransactionPayments
        {
            get { return _transactionPayments; }
            set { _transactionPayments = value; }
        }
        public int? ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }
        public string? MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
    }
}
