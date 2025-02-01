using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<string>> SearchItems()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("getItem/{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<ActionResult> AddItem([FromBody] string value)
        {
            return Ok();
        }

        [HttpPut]
        [Route("updateItem/{id}")]
        public async Task<ActionResult> UpdateItem(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("deleteItem/{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            return Ok();
        }
    }
}
