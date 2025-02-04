using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Model.PersonModels
{
    public class Member : Person
    {
        private readonly string? _memberId;
        private ICollection<Item>? _itemsBorrowed; 
        private decimal _fineAmountOwed;

        public Member(string firstName
                        ,string lastName
                        ,ContactInfo contactinfo
                        ,decimal fineAmountOwed
                        ,string? memberId = null
                        ,ICollection<Item>? itemsBorrowed = null) : base(firstName, lastName, contactinfo)
        {
            _memberId = memberId;
            _itemsBorrowed = itemsBorrowed;
            _fineAmountOwed = fineAmountOwed;
        }

        public string? MemberId
        {
            get { return _memberId; }
        }

        public ICollection<Item>? ItemsBorrowed
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
