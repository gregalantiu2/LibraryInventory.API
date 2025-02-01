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
        private Dictionary<string, object> _itemProperties;

        public ItemType(int itemTypeId, string itemTypeName, Dictionary<string, object> itemProperties)
        {
            _itemTypeId = itemTypeId;
            _itemTypeName = itemTypeName;
            _itemProperties = itemProperties;
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
            get { return _itemProperties; }
            set { _itemProperties = value; }
        }
    }
}
