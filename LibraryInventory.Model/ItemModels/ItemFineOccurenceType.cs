namespace LibraryInventory.Model.ItemModels
{
    public class ItemFineOccurenceType
    {
        private readonly int? _itemPolicyFineTypeId;
        private string _itemPolicyFineTypeName;

        public ItemFineOccurenceType(string itemPolicyFineTypeName, int? itemPolicyFineTypeId = null)
        {
            _itemPolicyFineTypeId = itemPolicyFineTypeId;
            _itemPolicyFineTypeName = itemPolicyFineTypeName;
        }

        public int? ItemPolicyFineTypeId
        {
            get { return _itemPolicyFineTypeId; }
        }

        public string ItemPolicyFineTypeName
        {
            get { return _itemPolicyFineTypeName; }
            set { _itemPolicyFineTypeName = value; }
        }
    }
}
