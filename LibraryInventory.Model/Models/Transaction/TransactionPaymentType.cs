using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Models.Transaction
{
    public class TransactionPaymentType
    {
        private readonly int _transactionPaymentTypeId;
        private string _transactionPaymentTypeName;

        public TransactionPaymentType(string transactionPaymentTypeName)
        {
            _transactionPaymentTypeName = transactionPaymentTypeName;
        }

        public int TransactionPaymentTypeId
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
