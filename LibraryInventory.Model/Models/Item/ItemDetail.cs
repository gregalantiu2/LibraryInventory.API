using LibraryInventory.Model.Enums;

namespace LibraryInventory.Model.Models.Product
{
    public class ItemDetail
    {
        private readonly int _itemDetailId;
        private string _itemTitle;
        private string _itemDescription;
        private ItemType _itemType;

        public ItemDetail(string title, string description)
        {
            _itemTitle = title;
            _itemDescription = description;
        }
        public int ItemDetailId
        {
            get { return _itemDetailId; }
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
    }
}
