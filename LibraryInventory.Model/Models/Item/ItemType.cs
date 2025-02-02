using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Models.Item
{
    public class ItemType
    {
        private readonly int _itemTypeId;
        private string _itemTypeName;
        private Dictionary<string, object> _itemAdditionalProperties;

        public ItemType(int itemTypeId, string itemTypeName, Dictionary<string, object> itemAdditionalProperties)
        {
            _itemTypeId = itemTypeId;
            _itemTypeName = itemTypeName;
            _itemAdditionalProperties = itemAdditionalProperties;
        }
        public int ItemTypeId
        {
            get { return _itemTypeId; }
        }
        public string ItemTypeName
        {
            get { return _itemTypeName; }
            set { _itemTypeName = value; }
        }
        public Dictionary<string, object> ItemProperties
        {
            get { return _itemAdditionalProperties; }
            set { _itemAdditionalProperties = value; }
        }
    }
}
