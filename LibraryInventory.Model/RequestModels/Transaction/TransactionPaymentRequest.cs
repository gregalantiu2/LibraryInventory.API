using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.RequestModels.Transaction
{
    public class TransactionPaymentRequest
    {
        public decimal Amount { get; set; }
        public required string MemberId { get; set; }
        public int PaymentTypeId { get; set; }  
    }
}
