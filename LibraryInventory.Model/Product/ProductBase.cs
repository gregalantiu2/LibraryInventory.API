using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Product
{
    public abstract class ProductBase
    {
        public MetaInfo MetaInfo { get; set; } = new MetaInfo();
        public FinancialInfo FinancialInfo { get; set; } = new FinancialInfo();
        public CheckoutInfo CheckoutInfo { get; set; } = new CheckoutInfo();
    }
}
