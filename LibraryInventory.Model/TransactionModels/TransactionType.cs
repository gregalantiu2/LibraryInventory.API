namespace LibraryInventory.Model.TransactionModels
{
    public class TransactionType
    {
        private readonly int? _transactionTypeId;
        private string _transactionTypeName;

        public TransactionType(string transactionTypeName, int? transactionTypeId = null)
        {
            _transactionTypeName = transactionTypeName;
            _transactionTypeId = transactionTypeId;
        }

        public int? TransactionTypeId
        {
            get { return _transactionTypeId; }
        }
        public string TransactionTypeName
        {
            get { return _transactionTypeName; }
            set { _transactionTypeName = value; }
        }
    }
}
