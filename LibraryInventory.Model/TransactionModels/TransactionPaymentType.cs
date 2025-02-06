namespace LibraryInventory.Model.TransactionModels
{
    public class TransactionPaymentType
    {
        private readonly int? _transactionPaymentTypeId;
        private string _transactionPaymentTypeName;

        public TransactionPaymentType(string transactionPaymentTypeName, int? transactionPaymentTypeId = null)
        {
            _transactionPaymentTypeName = transactionPaymentTypeName;
            _transactionPaymentTypeId = transactionPaymentTypeId;
        }

        public TransactionPaymentType(int transactionPaymentTypeId)
        {
            _transactionPaymentTypeId = transactionPaymentTypeId;
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
