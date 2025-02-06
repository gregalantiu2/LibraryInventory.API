using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Model.PersonModels
{
    public class Member : Person
    {
        private readonly string? _memberId;
        private int? _memberKeyId;
        private decimal _fineAmountOwed;

        public Member(string firstName
                        ,string lastName
                        ,ContactInfo contactinfo
                        ,decimal fineAmountOwed = 0.0m
                        ,string? memberId = null
                        ,int? memberKeyId = null) : base(firstName, lastName, contactinfo)
        {
            _memberId = memberId;
            _fineAmountOwed = fineAmountOwed;
            _memberKeyId = memberKeyId;
        }

        public string? MemberId
        {
            get { return _memberId; }
        }

        public int? MemberKeyId
        {
            get { return _memberKeyId; }
            set { _memberKeyId = value; }
        }

        public decimal FineAmountOwed
        {
            get { return _fineAmountOwed; }
            set { _fineAmountOwed = value; }
        }
    }
}
