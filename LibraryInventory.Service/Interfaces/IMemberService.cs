﻿using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> SearchMembersAsync(string searchTerm);
        Task<Member> AddMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member member);
        Task InactivateMemberAsync(string memberId);
        Task DeleteMemberAsync(string memberId);
        Task<Member> GetMemberbyMemberIdAsync(string memberId);
        Task<ContactInfo> GetMemberContactInfoAsync(string memberId);
        Task<decimal> GetMemberTotalAmountOwed(string memberId);
        Task<bool> MemberExistsAsync(string memberId);
    }
}
