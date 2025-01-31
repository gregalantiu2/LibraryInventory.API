namespace LibraryInventory.Model.Product
{
    public class MetaInfo
    {
        private long id;
        private long groupId;
        private string title = "";
        private string description = "";

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
