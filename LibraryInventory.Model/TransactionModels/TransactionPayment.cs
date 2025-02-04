﻿namespace LibraryInventory.Model.TransactionModels
{
    public class TransactionPayment
    {
        private readonly int? _transactionPaymentId;
        private decimal _paymentAmount;
        private TransactionPaymentType _transactionPaymentType;

        public TransactionPayment(decimal paymentAmount
                                    ,TransactionPaymentType transactionPaymentType
                                    ,int? transactionPaymentId = null)
        {
            _paymentAmount = paymentAmount;
            _transactionPaymentType = transactionPaymentType;
        }

        public int? TransactionPaymentId
        {
            get { return _transactionPaymentId; }
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
