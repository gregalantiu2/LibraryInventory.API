using LibraryInventory.API.RequestModels;
using LibraryInventory.Service.Interfaces;
using LibraryInventory.Model.ItemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using LibraryInventory.API.Extensions;
using LibraryInventory.Model.PersonModels;
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
            var result = await _itemService.SearchItemsAsync(searchTerm);

            return Ok(result);
        }

        [HttpGet]
        [Route("getItem/{itemId}")]
        public async Task<ActionResult> GetItem(int itemId)
        {
            var item = await _itemService.GetItemAsync(itemId);

            if (item == null)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<ActionResult> AddItem([FromBody] Item newItem)
        {
            if (newItem == null)
            {
                return BadRequest(MessageHelper<Item>.ObjectNull());
            }

            var item = await _itemService.AddItemAsync(newItem);

            return Ok(item);
        }

        [HttpPut]
        [Route("updateItem/{itemId}")]
        public async Task<ActionResult> UpdateItem(int itemId, [FromBody] Item item)
        {
            if (itemId != item.ItemId)
            {
                return BadRequest(MessageHelper<Item>.MismatchIds(itemId.ToString(), item.ItemId.ToString()));
            }

            var updatedItem = await _itemService.UpdateItemAsync(item);

            if (updatedItem == null)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            return Ok(updatedItem);
        }

        [HttpPut]
        [Route("inactivateItem/{itemId}")]
        public async Task<ActionResult> InactivateItem(int itemId)
        {
            if (await _itemService.ItemExistsAsync(itemId) == false)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            await _itemService.InactivateItemAsync(itemId);

            return NoContent();
        }

        [HttpDelete]
        [Route("deleteItem/{itemId}")]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            if (await _itemService.ItemExistsAsync(itemId) == false)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            await _itemService.DeleteItemAsync(itemId);

            return NoContent();
        }

        [HttpGet]
        [Route("getItemBorrowStatus/{itemId}")]
        public async Task<ActionResult> GetItemBorrowStatus(int itemId)
        {
            var status = await _itemService.GetItemBorrowStatusAsync(itemId);

            return Ok(status);
        }

        [HttpGet]
        [Route("getItemDetail/{itemId}")]
        public async Task<ActionResult> GetItemDetail(int itemId)
        {
            var detail = await _itemService.GetItemDetailAsync(itemId);

            return Ok(detail);
        }

        [HttpGet]
        [Route("getItemPolicy/{itemId}")]
        public async Task<ActionResult> GetPolicyForItem(int itemId)
        {
            var policy = await _itemService.GetItemPolicyAsync(itemId);

            return Ok(policy);
        }
    }
}
