namespace LibraryInventory.Model.ItemModels
{
    public class ItemFineOccurenceType
    {
        private readonly int? _itemFineOccurenceTypeId;
        private string? _itemFineOccurenceTypeDescription;

        public ItemFineOccurenceType (int itemFineOccurenceTypeId)
        {
            _itemFineOccurenceTypeId = itemFineOccurenceTypeId;
        }
        public ItemFineOccurenceType (string itemFineOccurenceTypeDescription)
        {
            _itemFineOccurenceTypeDescription = itemFineOccurenceTypeDescription;
        }

        public int? ItemFineOccurenceTypeId
        {
            get { return _itemFineOccurenceTypeId; }
        }

        public string? ItemFineOccurenceTypeDescription
        {
            get { return _itemFineOccurenceTypeDescription; }
            set { _itemFineOccurenceTypeDescription = value; }
        }
    }
}
