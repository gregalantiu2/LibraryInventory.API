using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult> SearchMembers()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getMember/{id}")]
        public async Task<ActionResult> GetMember(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("addMember")]
        public async Task<ActionResult> AddMember([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut]
        [Route("updateMember/{id}")]
        public async Task<ActionResult> UpdateMember(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpPut]
        [Route("inactivateMember/{id}")]
        public async Task<ActionResult> InactivateMember(int id)
        {
            return Ok();
        }
    }
}
