using LibraryInventory.Service.Interfaces;
using LibraryInventory.Model.ItemModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using LibraryInventory.API.Extensions;
using AutoMapper;
using LibraryInventory.Model.RequestModels.Item;
namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
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
        public async Task<ActionResult> AddItem([FromBody] ItemRequest newItem)
        {
            if (newItem == null)
            {
                return BadRequest(MessageHelper<Item>.ObjectNull());
            }

            var item = await _itemService.AddItemAsync(_mapper.Map<Item>(newItem));

            return Ok(item);
        }

        [HttpPut]
        [Route("updateItem/{itemId}")]
        public async Task<ActionResult> UpdateItem(int itemId, [FromBody] ItemRequest item)
        {
            if (itemId != item.ItemId)
            {
                return BadRequest(MessageHelper<Item>.MismatchIds(itemId.ToString(), item.ItemId.ToString()));
            }

            if (await _itemService.ItemExistsAsync(itemId) == false)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            var updatedItem = await _itemService.UpdateItemAsync(_mapper.Map<Item>(item));

            return Ok(updatedItem);
        }

        [HttpPut]
        [Route("inactivateItem/{itemId}")]
        public async Task<ActionResult> InactivateItem(int itemId)
        {
            if (!await _itemService.ItemExistsAsync(itemId))
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            await _itemService.InactivateItemAsync(itemId);

            return Ok(MessageHelper<Item>.Success());
        }

        [HttpDelete]
        [Route("deleteItem/{itemId}")]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            if (!await _itemService.ItemExistsAsync(itemId))
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.ToString()));
            }

            await _itemService.DeleteItemAsync(itemId);

            return Ok(MessageHelper<Item>.Success());
        }

        [HttpGet]
        [Route("getItemBorrowStatus/{itemId}")]
        public async Task<ActionResult> GetItemBorrowStatus(int itemId)
        {
            var status = await _itemService.GetItemBorrowStatusAsync(itemId);

            return Ok(status);
        }

        [HttpGet]
        [Route("getPolicyForItem/{itemId}")]
        public async Task<ActionResult> GetPolicyForItem(int itemId)
        {
            var policy = await _itemService.GetPolicyForItemAsync(itemId);

            if(policy == null)
            {
                return NotFound(MessageHelper<ItemPolicy>.NotFound(itemId.ToString()));
            }

            return Ok(policy);
        }

        [HttpGet]
        [Route("getItemPolicy/{itemPolicyId}")]
        public async Task<ActionResult> GetItemPolicy(int itemPolicyId)
        {
            var policy = await _itemService.GetItemPolicyAsync(itemPolicyId);

            if (policy == null)
            {
                return NotFound(MessageHelper<ItemPolicy>.NotFound(itemPolicyId.ToString()));
            }

            return Ok(policy);
        }

        [HttpPost]
        [Route("addItemPolicy")]
        public async Task<ActionResult> AddtemPolicyAsync([FromBody] ItemPolicyRequest itemPolicy)
        {
            if (itemPolicy == null)
            {
                return BadRequest(MessageHelper<ItemPolicy>.ObjectNull());
            }

            var policy = await _itemService.AddtemPolicyAsync(_mapper.Map<ItemPolicy>(itemPolicy));

            return Ok(policy);
        }

        [HttpPut]
        [Route("updateItemPolicy/{itemPolicyId}")]
        public async Task<ActionResult> UpdateItemPolicy(int itemPolicyId, [FromBody] ItemPolicyRequest itemPolicy)
        {
            if (itemPolicyId != itemPolicy.ItemPolicyId)
            {
                return BadRequest(MessageHelper<ItemPolicy>.MismatchIds(itemPolicyId.ToString(), itemPolicy.ItemPolicyId.ToString()));
            }

            if (!await _itemService.ItemPolicyExistsAsync(itemPolicyId))
            {
                return NotFound(MessageHelper<Item>.NotFound(itemPolicyId.ToString()));
            }

            var updatedPolicy = await _itemService.UpdateItemPolicyAsync(_mapper.Map<ItemPolicy>(itemPolicy));

            return Ok(updatedPolicy);
        }

        [HttpDelete]
        [Route("deleteItemPolicy/{itemPolicyId}")]
        public async Task<ActionResult> DeleteItemPolicy(int itemPolicyId)
        {
            if (await _itemService.ItemPolicyExistsAsync(itemPolicyId) == false)
            {
                return NotFound(MessageHelper<ItemPolicy>.NotFound(itemPolicyId.ToString()));
            }

            await _itemService.DeleteItemPolicyAsync(itemPolicyId);

            return Ok(MessageHelper<ItemPolicy>.Success());
        }
    }
}
