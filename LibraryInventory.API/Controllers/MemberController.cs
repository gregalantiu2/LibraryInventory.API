using AutoMapper;
using LibraryInventory.API.Extensions;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.RequestModels.Person;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public MemberController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("search/{searchTerm}")]
        public async Task<ActionResult> SearchMembers(string searchTerm)
        {
            if (searchTerm.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(searchTerm)));
            }

            var result = await _memberService.SearchMembersAsync(searchTerm);

            return Ok(result);
        }

        [HttpGet]
        [Route("getMember/{memberId}")]
        public async Task<ActionResult> GetMemberByMemberId(string memberId)
        {
            if (memberId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            var member = await _memberService.GetMemberbyMemberIdAsync(memberId);

            if (member == null)
            {
                return NotFound(MessageHelper<Member>.NotFound(memberId));
            }

            return Ok(member);
        }

        [HttpGet]
        [Route("getMemberContactInfo/{memberId}")]
        public async Task<ActionResult> GetMemberContactInfo(string memberId)
        {
            if (memberId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            var contactInfo = await _memberService.GetMemberContactInfoAsync(memberId);

            return Ok(contactInfo);
        }

        [HttpGet]
        [Route("getTotalAmountOwed/{memberId}")]
        public async Task<ActionResult> GetTotalAmountOwed(string memberId)
        {
            if (memberId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            var totalAmountOwed = await _memberService.GetMemberTotalAmountOwed(memberId);

            return Ok(totalAmountOwed);
        }

        [HttpPost]
        [Route("addMember")]
        public async Task<ActionResult> AddMember([FromBody] MemberRequest newMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _memberService.AddMemberAsync(_mapper.Map<Member>(newMember));

            return Ok(member);
        }

        [HttpPut]
        [Route("updateMember/{memberId}")]
        public async Task<ActionResult> UpdateMember(string memberId, [FromBody] MemberRequest member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (memberId != member.MemberId)
            {
                return BadRequest($"{memberId} query param does not match memberId in resource object");
            }

            var updatedMember = await _memberService.UpdateMemberAsync(_mapper.Map<Member>(member));

            return Ok(updatedMember);
        }

        [HttpPut]
        [Route("inactivateMember/{memberId}")]
        public async Task<ActionResult> InactivateMember(string memberId)
        {
            if (memberId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            await _memberService.InactivateMemberAsync(memberId);

            return Ok(MessageHelper<Member>.Success());
        }

        [HttpDelete]
        [Route("deleteMember/{memberId}")]
        public async Task<ActionResult> DeleteMember(string memberId)
        {
            if (memberId.IsNullOrEmpty())
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            await _memberService.DeleteMemberAsync(memberId);

            return Ok(MessageHelper<Member>.Success());
        }
    }
}
