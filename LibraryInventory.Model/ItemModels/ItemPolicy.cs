namespace LibraryInventory.Model.ItemModels
{
    public class ItemPolicy
    {
        private readonly int _itemPolicyId;
        private string _policyName;
        private bool _allowedToCheckout;
        private int _maxRenewalsAllowed;
        private int _checkoutDays;
        private decimal _fineAmount;
        private ItemFineOccurenceType _fineOccurrence;

        public ItemPolicy(string policyName, bool allowedToCheckout, int maxRenewalsAllowed, int checkoutDays, decimal fineAmount, ItemFineOccurenceType fineOccurrence)
        {
            _policyName = policyName;
            _allowedToCheckout = allowedToCheckout;
            _maxRenewalsAllowed = maxRenewalsAllowed;
            _checkoutDays = checkoutDays;
            _fineAmount = fineAmount;
            _fineOccurrence = fineOccurrence;
        }

        public int ItemPolicyId
        {
            get { return _itemPolicyId; }
        }

        public string PolicyName
        {
            get { return _policyName; }
            set { _policyName = value; }
        }

        public bool AllowedToCheckout
        {
            get { return _allowedToCheckout; }
            set { _allowedToCheckout = value; }
        }
        public int MaxRenewalsAllowed
        {
            get { return _maxRenewalsAllowed; }
            set { _maxRenewalsAllowed = value; }
        }
        public int CheckoutDays
        {
            get { return _checkoutDays; }
            set { _checkoutDays = value; }
        }
        public decimal FineAmount
        {
            get { return _fineAmount; }
            set { _fineAmount = value; }
        }

        public ItemFineOccurenceType FineOccurrence
        {
            get { return _fineOccurrence; }
            set { _fineOccurrence = value; }
        }
    }
}
