using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Enums
{
    public enum TransactionType
    {
        CheckOut,
        CheckIn,
        Renewal,
        Bought,
        Sold,
        DonatedToLibrary,
        DonatedByLibrary,
        Lost
    }
}
