using LibraryInventory.Model.Models.Person;

namespace LibraryInventory.Service.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> SearchMembers(string searchTerm);
        Member AddMember(Member member);
        Member UpdateItem(Member member);
        void InactivateMember(int memberId);
        Member GetMember(string memberId);
    }
}
