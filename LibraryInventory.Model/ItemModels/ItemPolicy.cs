namespace LibraryInventory.Model.ItemModels
{
    public class ItemPolicy
    {
        private readonly int? _itemPolicyId;
        private string? _itemPolicyName;
        private bool? _allowedToCheckout;
        private int? _maxRenewalsAllowed;
        private int? _checkoutDays;
        private decimal? _fineAmount;
        private ItemFineOccurenceType? _itemFineOccurenceType;

        public ItemPolicy(int itemPolicyId)
        {
            _itemPolicyId = itemPolicyId;
        }

        public ItemPolicy(string itemPolicyName
                           ,bool allowedToCheckout
                           ,int maxRenewalsAllowed
                           ,int checkoutDays
                           ,decimal fineAmount
                           ,ItemFineOccurenceType itemFineOccurenceType
                           ,int? itemPolicyId = null)
        {
            _itemPolicyName = itemPolicyName;
            _allowedToCheckout = allowedToCheckout;
            _maxRenewalsAllowed = maxRenewalsAllowed;
            _checkoutDays = checkoutDays;
            _fineAmount = fineAmount;
            _itemFineOccurenceType = itemFineOccurenceType;
            _itemPolicyId = itemPolicyId;
        }

        public int? ItemPolicyId
        {
            get { return _itemPolicyId; }
        }

        public string? ItemPolicyName
        {
            get { return _itemPolicyName; }
            set { _itemPolicyName = value; }
        }

        public bool? AllowedToCheckout
        {
            get { return _allowedToCheckout; }
            set { _allowedToCheckout = value; }
        }
        public int? MaxRenewalsAllowed
        {
            get { return _maxRenewalsAllowed; }
            set { _maxRenewalsAllowed = value; }
        }
        public int? CheckoutDays
        {
            get { return _checkoutDays; }
            set { _checkoutDays = value; }
        }
        public decimal? FineAmount
        {
            get { return _fineAmount; }
            set { _fineAmount = value; }
        }

        public ItemFineOccurenceType? ItemFineOccurenceType
        {
            get { return _itemFineOccurenceType; }
            set { _itemFineOccurenceType = value; }
        }
    }
}
