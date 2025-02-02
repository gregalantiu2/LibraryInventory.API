using LibraryInventory.Model.Models.Shared;

namespace LibraryInventory.Model.Models.Person
{
    public class Member : Person
    {
        private readonly string _memberId;
        private int _itemsBorrowed;
        private decimal _fineAmountOwed;

        public Member(string firstName
                        ,string lastName
                        ,ContactInfo contactinfo) : base(firstName, lastName, contactinfo)
        {

        }

        public string MemberId
        {
            get { return _memberId; }
        }

        public int ItemsBorrowed
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
