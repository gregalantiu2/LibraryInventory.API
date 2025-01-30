using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Product
{
    public class FinancialInfo
    {
        private decimal fineAmount = 0.0m;
        private FineType fineOccurrence = FineType.Daily;
        private decimal purchasedPrice;
        private decimal retailValue;

        public decimal FineAmount
        {
            get { return fineAmount; }
            set { fineAmount = value; }
        }

        public FineType FineOccurrence
        {
            get { return fineOccurrence; }
            set { fineOccurrence = value; }
        }

        public decimal PurchasedPrice
        {
            get { return purchasedPrice; }
            set { purchasedPrice = value; }
        }

        public decimal RetailValue
        {
            get { return retailValue; }
            set { retailValue = value; }
        }

        public enum FineType
        {
            Daily,
            Weekly,
            Monthly
        }
    }
}
