using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberEntity>> SearchMembersAsync(string searchTerm);
        Task<MemberEntity> AddMemberAsync(MemberEntity member);
        Task<MemberEntity> UpdateMemberAsync(MemberEntity member);
        Task InactivateMemberAsync(string memberId);
        Task DeleteMemberAsync(string memberId);
        Task<MemberEntity> GetMemberbyMemberIdAsync(string memberId);
        Task<ContactInfo> GetMemberContactInfoAsync(string memberId);
        Task<decimal> GetMemberTotalAmountOwed(string memberId);
        Task<bool> MemberExistsAsync(string memberId);

    }
}
