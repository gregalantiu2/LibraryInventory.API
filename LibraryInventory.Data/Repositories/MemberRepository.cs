using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Task<MemberEntity> AddMemberAsync(MemberEntity member)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMemberAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<MemberEntity> GetMemberbyMemberIdAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfo> GetMemberContactInfoAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetMemberTotalAmountOwed(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task InactivateMemberAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MemberExistsAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MemberEntity>> SearchMembersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<MemberEntity> UpdateMemberAsync(MemberEntity member)
        {
            throw new NotImplementedException();
        }
    }
}
