using LibraryInventory.Model.Enums;

namespace LibraryInventory.Model.Models.Transaction
{
    public class Transaction
    {
        private int _transactionId;
        private TransactionType _transactionType;
        private DateTime _transactionDate;
        private int _itemId;
        private int _memberId;
        private string _createdBy;

        public Transaction(TransactionType transactionType, DateTime transactionDate, int itemId, int memberId, string createdBy)
        {
            _transactionType = transactionType;
            _transactionDate = transactionDate;
            _itemId = itemId;
            _memberId = memberId;
            _createdBy = createdBy;
        }

        public int TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
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

        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy; }
        }
    }
}
