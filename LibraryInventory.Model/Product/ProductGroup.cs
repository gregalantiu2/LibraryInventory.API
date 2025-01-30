using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Product
{
    public class ProductGroup
    {
        private int groupId;
        private string title = "";
        private string description = "";

        public int GroupId
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
