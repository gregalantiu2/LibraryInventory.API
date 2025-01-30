namespace LibraryInventory.Model.Product
{
    public abstract class ProductBase
    {
        private MetaInfo _metaInfo = new MetaInfo();
        private FinancialInfo _financialInfo = new FinancialInfo();
        private CheckoutInfo _checkoutInfo = new CheckoutInfo();

        public MetaInfo MetaInfo
        {
            get { return _metaInfo; }
            set { _metaInfo = value; }
        }

        public FinancialInfo FinancialInfo
        {
            get { return _financialInfo; }
            set { _financialInfo = value; }
        }

        public CheckoutInfo CheckoutInfo
        {
            get { return _checkoutInfo; }
            set { _checkoutInfo = value; }
        }
    }
}
