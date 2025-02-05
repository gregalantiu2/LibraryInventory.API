namespace LibraryInventory.Model.TransactionModels
{
    public class TransactionPaymentType
    {
        private readonly int? _transactionPaymentTypeId;
        private string _transactionPaymentTypeName;

        public TransactionPaymentType(string transactionPaymentTypeName, int? transctionPaymentId = null)
        {
            _transactionPaymentTypeName = transactionPaymentTypeName;
            _transactionPaymentTypeId = transctionPaymentId;
        }

        public TransactionPaymentType(int transctionPaymentId)
        {
            _transactionPaymentTypeId = transctionPaymentId;
        }

        public int? TransactionPaymentTypeId
        {
            get { return _transactionPaymentTypeId; }
        }
        public string TransactionPaymentTypeName
        {
            get { return _transactionPaymentTypeName; }
            set { _transactionPaymentTypeName = value; }
        }
    }
}
