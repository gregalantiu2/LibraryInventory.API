using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Model.PersonModels
{
    public class Member : Person
    {
        private readonly string? _memberId;
        private List<Item>? _itemsBorrowed; 
        private decimal _fineAmountOwed;

        public Member(string firstName
                        ,string lastName
                        ,ContactInfo contactinfo) : base(firstName, lastName, contactinfo)
        {

        }

        public string? MemberId
        {
            get { return _memberId; }
        }

        public List<Item>? ItemsBorrowed
        {
            get { return _itemsBorrowed; }
            set { _itemsBorrowed = value; }
        }

        public decimal FineAmountOwed
        {
            get { return _fineAmountOwed; }
            set { _fineAmountOwed = value; }
        }
    }
}
