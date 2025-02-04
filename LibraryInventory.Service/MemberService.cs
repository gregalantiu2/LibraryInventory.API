using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public  class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public  MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<Member> AddMemberAsync(Member member)
        {
            var result = await _memberRepository.AddMemberAsync(_mapper.Map<MemberEntity>(member));
            return _mapper.Map<Member>(result);;
        }

        public async Task DeleteMemberAsync(string memberId)
        {
            await _memberRepository.DeleteMemberAsync(memberId);
        }

        public async Task<Member> GetMemberbyMemberIdAsync(string memberId)
        {
            var result = await _memberRepository.GetMemberbyMemberIdAsync(memberId);
            return _mapper.Map<Member>(result);
        }

        public async Task<ContactInfo> GetMemberContactInfoAsync(string memberId)
        {
            var result = await _memberRepository.GetMemberContactInfoAsync(memberId);
            return _mapper.Map<ContactInfo>(result);
        }

        public async Task<decimal> GetMemberTotalAmountOwed(string memberId)
        {
            return await _memberRepository.GetMemberTotalAmountOwed(memberId);
        }

        public async Task InactivateMemberAsync(string memberId)
        {
            await _memberRepository.InactivateMemberAsync(memberId);
        }

        public async Task<bool> MemberExistsAsync(string memberId)
        {
            return await _memberRepository.MemberExistsAsync(memberId);
        }

        public async Task<IEnumerable<Member>> SearchMembersAsync(string searchTerm)
        {
            var result = await _memberRepository.SearchMembersAsync(searchTerm);
            return _mapper.Map<IEnumerable<Member>>(result);
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            var result = await _memberRepository.UpdateMemberAsync(_mapper.Map<MemberEntity>(member));
            return _mapper.Map<Member>(result);
        }
    }
}
