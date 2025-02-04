namespace LibraryInventory.Model.ItemModels
{
    public class Item
    {
        private readonly int? _itemId;
        private ItemDetail _itemDetail;
        private ItemPolicy? _itemPolicy;
        private ItemBorrowStatus? _itemBorrowStatus;
        private string? _itemLocation;
        private bool _itemActive;

        public Item(ItemDetail itemDetail
                    ,string? itemLocation = null
                    ,ItemPolicy? itemPolicy = null
                    ,ItemBorrowStatus? itemBorrowStatus = null
                    ,int? itemId = null)
        {
            _itemDetail = itemDetail;
            _itemLocation = itemLocation;
            _itemPolicy = itemPolicy;
            _itemBorrowStatus = itemBorrowStatus;
            _itemActive = true;
            _itemId = itemId;
        }

        public int? ItemId
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
        public ItemBorrowStatus? ItemBorrowStatus
        {
            get { return _itemBorrowStatus; }
            set { _itemBorrowStatus = value; }
        }
        public string? ItemLocation
        {
            get { return _itemLocation; }
            set { _itemLocation = value; }
        }
        public bool ItemActive
        {
            get { return _itemActive; }
            set
            {
                _itemActive = value;
                _itemBorrowStatus = _itemActive == false ? null : _itemBorrowStatus;
                _itemLocation = null;
                _itemPolicy = null;
            }
        }
    }
}
