using System.Runtime.CompilerServices;

namespace LibraryInventory.Model.ItemModels
{
    public class Item
    {
        private readonly int? _itemId;
        private string _itemTitle;
        private string _itemDescription;
        private ItemType _itemType;
        private ItemPolicy? _itemPolicy;
        private ItemBorrowStatus? _itemBorrowStatus;
        private string? _itemLocation;
        private bool _itemActive;

        public Item(string itemTitle
                    ,string itemDescription
                    ,ItemType itemType
                    ,ItemPolicy? itemPolicy = null
                    ,ItemBorrowStatus? itemBorrowStatus = null
                    ,string? itemLocation = null
                    ,int? itemId = null)
        {
            _itemTitle = itemTitle;
            _itemDescription = itemDescription;
            _itemType = itemType;
            _itemPolicy = itemPolicy;
            _itemBorrowStatus = itemBorrowStatus;
            _itemLocation = itemLocation;
            _itemId = itemId;
            _itemActive = true;
        }

        public int? ItemId
        {
            get { return _itemId; }
        }
        public string ItemTitle
        {
            get { return _itemTitle; }
            set { _itemTitle = value; }
        }
        public string ItemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }
        public ItemType ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
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
