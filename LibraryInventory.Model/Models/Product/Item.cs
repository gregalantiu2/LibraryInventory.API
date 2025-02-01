namespace LibraryInventory.Model.Models.Product
{
    public abstract class Item
    {
        private int _itemId;
        private ItemDetail _itemDetail;
        private ItemPolicy? _itemPolicy;
        private bool _isCheckedOut;
        private DateTime? _checkedOutDate;
        private DateTime? _dueBack;
        private int _renewedCount;

        public Item(ItemDetail itemDetail, ItemPolicy? itemPolicy = null)
        {
            _itemDetail = itemDetail;
            _itemPolicy = itemPolicy;
        }
        public int ItemId
        {
            get { return _itemId; }
        }
        public ItemDetail ItemDetail
        {
            get { return _itemDetail; }
            set { _itemDetail = value; }
        }
        public ItemPolicy? ItemPolicy
        {
            get { return _itemPolicy; }
            set { _itemPolicy = value; }
        }
        public bool IsCheckedOut
        {
            get { return _isCheckedOut; }
            set { _isCheckedOut = value; }
        }
        public DateTime? CheckedOutDate
        {
            get { return _checkedOutDate; }
            set { _checkedOutDate = _isCheckedOut == false ? null : value; }
        }
        public DateTime? DueBack
        {
            get { return _dueBack; }
            set { _dueBack = value; }
        }
        public int RenewedCount
        {
            get { return _renewedCount; }
            set 
            {
                _renewedCount = _isCheckedOut == false ? 0 : value; 
            }
        }
    }
}
