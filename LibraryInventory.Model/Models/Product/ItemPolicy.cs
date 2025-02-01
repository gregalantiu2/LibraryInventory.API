using LibraryInventory.Model.Enums;

namespace LibraryInventory.Model.Models.Product
{
    public class ItemPolicy
    {
        private readonly int _itemPolicyId;
        private string _policyName = "Custom";
        private bool _allowedToCheckout;
        private int _maxRenewalsAllowed;
        private int _checkoutDays;
        private decimal _fineAmount;
        private FineType _fineOccurrence;

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

        public FineType FineOccurrence
        {
            get { return _fineOccurrence; }
            set { _fineOccurrence = value; }
        }
    }
}
