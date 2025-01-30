using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Product
{
    public class MetaInfo
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
