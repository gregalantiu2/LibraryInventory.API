using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryInventoryDbContext _context;

        public MemberRepository(LibraryInventoryDbContext context)
        {
            _context = context;
        }

        public async Task<MemberEntity> AddMemberAsync(MemberEntity member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task DeleteMemberAsync(string memberId)
        {
            var rowsAffected = await _context.Members.Where(m => m.MemberId == memberId)
                .ExecuteDeleteAsync();

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"Member {memberId} not found");
            }
        }

        public async Task<MemberEntity> GetMemberbyMemberIdAsync(string memberId)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == memberId);

            if (member == null)
            {
                throw new InvalidOperationException($"Member {memberId} not found");
            }

            return member;
        }

        public async Task<ContactInfoEntity> GetMemberContactInfoAsync(string memberId)
        {
            var contactInfo = await _context.Members.Where(m => m.MemberId == memberId)
                .Select(m => m.ContactInfo)
                .FirstOrDefaultAsync();

            if (contactInfo == null)
            {
                throw new InvalidOperationException($"Member {memberId} contact info not found");
            }

            return contactInfo;
        }

        public async Task<decimal> GetMemberTotalAmountOwed(string memberId)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == memberId);

            if (member == null)
            {
                throw new InvalidOperationException($"Member {memberId} not found");
            }

            return member?.FineAmountOwed ?? 0;
        }

        public async Task InactivateMemberAsync(string memberId)
        {
            var rowsAffected = await _context.Members.Where(m => m.MemberId == memberId)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(mem => mem.Active, false));

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"Member {memberId} not found");
            }
        }

        public async Task<bool> MemberExistsAsync(string memberId)
        {
            return await _context.Members.AnyAsync(m => m.MemberId == memberId);
        }

        public async Task<IEnumerable<MemberEntity>> SearchMembersAsync(string searchTerm)
        {
            return await _context.Members
                .Where(m => m.FirstName.Contains(searchTerm) || m.LastName.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<MemberEntity> UpdateMemberAsync(MemberEntity updateMember)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == updateMember.MemberId);

                if (member == null)
                {
                    throw new InvalidOperationException($"Member {updateMember.MemberId} not found");
                }

                member.FirstName = updateMember.FirstName;
                member.MiddleName = updateMember.MiddleName;
                member.LastName = updateMember.LastName;
                member.FineAmountOwed = updateMember.FineAmountOwed;

                var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.ContactInfoId == member.ContactInfoId);

                if (contactInfo == null)
                {
                    await _context.ContactInfos.AddAsync(updateMember.ContactInfo);
                    await _context.SaveChangesAsync();
                    member.ContactInfoId = updateMember.ContactInfo.ContactInfoId;
                }
                else
                {
                    contactInfo.Email = updateMember.ContactInfo.Email;
                    contactInfo.PhoneNumber = updateMember.ContactInfo.PhoneNumber;
                    contactInfo.Street = updateMember.ContactInfo.Street;
                    contactInfo.City = updateMember.ContactInfo.City;
                    contactInfo.State = updateMember.ContactInfo.State;
                    contactInfo.ZipCode = updateMember.ContactInfo.ZipCode;
                    contactInfo.Country = updateMember.ContactInfo.Country;
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return member;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
