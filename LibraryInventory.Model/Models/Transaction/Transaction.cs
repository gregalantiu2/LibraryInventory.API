namespace LibraryInventory.Model.Models.Transaction
{
    public class Transaction
    {
        private readonly int _transactionId;
        private TransactionType _transactionType;
        private DateTime _transactionDate;
        private TransactionPayment? _transactionPayment;
        private int _itemId;
        private int? _memberId;

        public Transaction(TransactionType transactionType
                            ,DateTime transactionDate
                            ,int itemId
                            , TransactionPayment? transactionPayment = null
                            ,int? memberId = null)
        {
            _transactionType = transactionType;
            _transactionDate = transactionDate;
            _transactionPayment = transactionPayment;
            _itemId = itemId;
            _memberId = memberId;
        }

        public int TransactionId
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

        public TransactionPayment? TransactionPayment
        {
            get { return _transactionPayment; }
            set { _transactionPayment = value; }
        }

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public int? MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
    }
}
