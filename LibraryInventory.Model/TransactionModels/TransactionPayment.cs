namespace LibraryInventory.Model.TransactionModels
{
    public class TransactionPayment
    {
        private readonly int? _transactionPaymentId;
        private decimal _paymentAmount;
        private TransactionPaymentType _transactionPaymentType;
        private int? _transactionId;

        public TransactionPayment(decimal paymentAmount
                                    ,TransactionPaymentType transactionPaymentType
                                    ,int? transactionId = null
                                    ,int? transactionPaymentId = null)
        {
            _paymentAmount = paymentAmount;
            _transactionPaymentType = transactionPaymentType;
            _transactionId = transactionId; 
        }

        public int? TransactionPaymentId
        {
            get { return _transactionPaymentId; }
        }

        public int? TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        public decimal PaymentAmount
        {
            get { return _paymentAmount; }
            set { _paymentAmount = value; }
        }

        public TransactionPaymentType TransactionPaymentType
        {
            get { return _transactionPaymentType; }
            set { _transactionPaymentType = value; }
        }
    }
}
