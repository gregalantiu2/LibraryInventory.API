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
    [Route("api/v1/[controller]")]
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
        public async Task<ActionResult> GetItem(int? itemId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemId)));
            }

            var item = await _itemService.GetItemAsync(itemId.Value);

            if (item == null)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.Value.ToString()));
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<ActionResult> AddItem([FromBody] ItemRequest newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = await _itemService.AddItemAsync(_mapper.Map<Item>(newItem));

            return Ok(item);
        }

        [HttpPut]
        [Route("updateItem/{itemId}")]
        public async Task<ActionResult> UpdateItem(int itemId, [FromBody] ItemRequest item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (itemId != item.ItemId)
            {
                return BadRequest(MessageHelper<Item>.MismatchIds(itemId.ToString(), item.ItemId.ToString()));
            }

            var updatedItem = await _itemService.UpdateItemAsync(_mapper.Map<Item>(item));

            return Ok(updatedItem);
        }

        [HttpPut]
        [Route("inactivateItem/{itemId}")]
        public async Task<ActionResult> InactivateItem(int? itemId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemId)));
            }
            
            await _itemService.InactivateItemAsync(itemId.Value);

            return Ok(MessageHelper<Item>.Success());
        }

        [HttpDelete]
        [Route("deleteItem/{itemId}")]
        public async Task<ActionResult> DeleteItem(int? itemId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemId)));
            }

            await _itemService.DeleteItemAsync(itemId.Value);

            return Ok(MessageHelper<Item>.Success());
        }

        [HttpGet]
        [Route("getItemBorrowStatus/{itemId}")]
        public async Task<ActionResult> GetItemBorrowStatus(int? itemId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemId)));
            }

            var status = await _itemService.GetItemBorrowStatusAsync(itemId.Value);

            return Ok(status);
        }

        [HttpGet]
        [Route("getPolicyForItem/{itemId}")]
        public async Task<ActionResult> GetPolicyForItem(int? itemId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemId)));
            }

            var policy = await _itemService.GetPolicyForItemAsync(itemId.Value);

            if(policy == null)
            {
                return NotFound(MessageHelper<ItemPolicy>.NotFound(itemId.Value.ToString()));
            }

            return Ok(policy);
        }

        [HttpGet]
        [Route("getItemPolicy/{itemPolicyId}")]
        public async Task<ActionResult> GetItemPolicy(int? itemPolicyId)
        {
            if (itemPolicyId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemPolicyId)));
            }

            var policy = await _itemService.GetItemPolicyAsync(itemPolicyId.Value);

            if (policy == null)
            {
                return NotFound(MessageHelper<ItemPolicy>.NotFound(itemPolicyId.Value.ToString()));
            }

            return Ok(policy);
        }

        [HttpPost]
        [Route("addItemPolicy")]
        public async Task<ActionResult> AddtemPolicyAsync([FromBody] ItemPolicyRequest itemPolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedPolicy = await _itemService.UpdateItemPolicyAsync(_mapper.Map<ItemPolicy>(itemPolicy));

            return Ok(updatedPolicy);
        }

        [HttpDelete]
        [Route("deleteItemPolicy/{itemPolicyId}")]
        public async Task<ActionResult> DeleteItemPolicy(int? itemPolicyId)
        {
            if (itemPolicyId == null)
            {
                return BadRequest(MessageHelper<Item>.RequiredParam(nameof(itemPolicyId)));
            }

            await _itemService.DeleteItemPolicyAsync(itemPolicyId.Value);

            return Ok(MessageHelper<ItemPolicy>.Success());
        }
    }
}
