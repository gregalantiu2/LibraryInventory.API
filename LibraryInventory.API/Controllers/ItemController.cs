using LibraryInventory.API.RequestModels;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
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
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        [Route("search/{searchTerm}")]
        public async Task<ActionResult> SearchItems([FromBody] SearchItemRequest searchItemRequest, string searchTerm)
        {
            var result = _itemService.SearchItems(searchItemRequest.ItemTypes, searchItemRequest.Properties, searchTerm);
            return Ok();
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
