namespace LibraryInventory.Model.ItemModels
{
    public class ItemType
    {
        private int? _itemTypeId;
        private string? _itemTypeName;
        private Dictionary<string, object>? _itemAdditionalProperties;

        public ItemType(int itemTypeId)
        {
            _itemTypeId = itemTypeId;
        }

        public ItemType(string itemTypeName, Dictionary<string, object> itemAdditionalProperties)
        {
            _itemTypeName = itemTypeName;
            _itemAdditionalProperties = itemAdditionalProperties;
        }

        public int? ItemTypeId
        {
            get { return _itemTypeId; }
            set { _itemTypeId = value; }
        }

        public string? ItemTypeName
        {
            get { return _itemTypeName; }
            set { _itemTypeName = value; }
        }

        public Dictionary<string, object>? ItemProperties
        {
            get { return _itemAdditionalProperties; }
            set { _itemAdditionalProperties = value; }
        }
    }
}
