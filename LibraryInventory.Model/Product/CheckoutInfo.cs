using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Product
{
    public class CheckoutInfo
    {
        private bool isCheckedOut;
        private DateTime? dueBack;
        private int checkoutDays;
        private int renewalDays;
        private int maxRenewals;
        private int checkedOutCount;

        public bool IsCheckedOut
        {
            get { return isCheckedOut; }
            set { isCheckedOut = value; }
        }

        public DateTime? DueBack
        {
            get { return dueBack; }
            set { dueBack = value; }
        }

        public int CheckoutDays
        {
            get { return checkoutDays; }
            set { checkoutDays = value; }
        }

        public int RenewalDays
        {
            get { return renewalDays; }
            set { renewalDays = value; }
        }

        public int MaxRenewals
        {
            get { return maxRenewals; }
            set { maxRenewals = value; }
        }

        public int DaysOverdue
        {
            get
            {
                if (DueBack.HasValue && DateTime.Now.Date > DueBack.Value.Date)
                {
                    return (DateTime.Now.Date - DueBack.Value.Date).Days;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int CheckedOutCount
        {
            get { return checkedOutCount; }
            set { checkedOutCount = value; }
        }
    }
}
