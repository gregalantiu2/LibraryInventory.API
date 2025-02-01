namespace LibraryInventory.Model.Models.Product
{
    public class ItemDetail
    {
        private readonly int _itemDetailId;
        private string _title;
        private string _description;

        public ItemDetail(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public int ItemDetailId
        {
            get { return _itemDetailId; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
