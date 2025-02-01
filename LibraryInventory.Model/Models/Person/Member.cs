using LibraryInventory.Model.Models.Shared;

namespace LibraryInventory.Model.Models.Person
{
    public class Member : Person
    {
        private readonly string _memberId;
        public Member(string firstName, string lastName, ContactInfo contactinfo) : base(firstName, lastName, contactinfo)
        {

        }
        public string MemberId
        {
            get { return _memberId; }
        }
    }
}
