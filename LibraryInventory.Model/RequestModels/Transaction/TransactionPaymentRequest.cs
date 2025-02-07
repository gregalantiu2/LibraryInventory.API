using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.RequestModels.Transaction
{
    public class TransactionPaymentRequest
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public required string MemberId { get; set; }
        [Required]
        public int PaymentTypeId { get; set; }  
    }
}
