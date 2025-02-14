﻿using LibraryInventory.API.Extensions;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.RequestModels.Transaction;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Member = LibraryInventory.Model.PersonModels.Member;
using Transaction = LibraryInventory.Model.TransactionModels.Transaction;

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IItemService _itemService;
        private readonly IMemberService _memberService;

        public TransactionController(ITransactionService transactionService, IItemService itemService, IMemberService memberService)
        {
            _transactionService = transactionService;
            _itemService = itemService;
            _memberService = memberService;
        }

        [HttpGet]
        [Route("getTransaction/{transactionId}")]
        public async Task<ActionResult> GetTransaction(int? transactionId)
        {
            if (transactionId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(transactionId)));
            }

            var transaction = await _transactionService.GetTransactionAsync(transactionId.Value);

            if (transaction == null)
            {
                return NotFound(MessageHelper<Transaction>.NotFound(transactionId.Value.ToString()));
            }

            return Ok(transaction);
        }

        [HttpGet]
        [Route("getTransactionsByMember/{memberId}")]
        public async Task<ActionResult> GetTransactionsByMember(int? memberId, int? daysToLookBack = null)
        {
            if (memberId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            var transactions = await _transactionService.GetTransactionsByMemberAsync(memberId.Value, daysToLookBack);

            return Ok(transactions);
        }

        [HttpGet]
        [Route("getTransactionsByItem/{itemId}")]
        public async Task<ActionResult> GetTransactionsByItem(int? itemId, int? daysToLookBack = null)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(itemId)));
            }

            var transactions = await _transactionService.GetTransactionsByItemAsync(itemId.Value, daysToLookBack);

            return Ok(transactions);
        }

        [HttpGet]
        [Route("getTransactionTypes")]
        public async Task<ActionResult> GetTransactionTypes()
        {
            var transactionTypes = await _transactionService.GetTransactionTypesAsync();

            return Ok(transactionTypes);
        }

        [HttpGet]
        [Route("getTransactionsByType/{transactionTypeId}")]
        public async Task<ActionResult> GetTransactionsByType(int? transactionTypeId, int? daysToLookBack = null)
        {
            if (transactionTypeId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(transactionTypeId)));
            }

            var transactions = await _transactionService.GetTransactionsByTypeAsync(transactionTypeId.Value, daysToLookBack);

            return Ok(transactions);
        }

        [HttpPost]
        [Route("checkoutItemTransaction")]
        public async Task<ActionResult> CheckoutItemTransaction(int? itemId, string memberId)
        {
            if (itemId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(itemId)));
            }

            if (memberId == null)
            {
                return BadRequest(MessageHelper<Employee>.RequiredParam(nameof(memberId)));
            }

            var item = await _itemService.GetItemAsync(itemId.Value);

            if (item == null)
            {
                return NotFound(MessageHelper<Item>.NotFound(itemId.Value.ToString()));
            }

            var member = await _memberService.GetMemberbyMemberIdAsync(memberId);

            if (member == null)
            {
                return NotFound(MessageHelper<Member>.NotFound(memberId));
            }

            await _transactionService.CheckoutItemTransactionAsync(item, member);

            return Ok(MessageHelper<Transaction>.Success());
        }

        [HttpPost]
        [Route("returnItemTransaction")]
        public async Task<ActionResult> ReturnItemTransaction([FromBody] TransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _memberService.GetMemberbyMemberIdAsync(request.MemberId);

            if (member == null)
            {
                return NotFound(MessageHelper<Member>.NotFound(request.MemberId));
            }

            await _transactionService.ReturnItemTransactionAsync(request.ItemId, member);

            return Ok(MessageHelper<Transaction>.Success());
        }

        [HttpPost]
        [Route("renewItemTranaction")]
        public async Task<ActionResult> RenewItemTransaction([FromBody] TransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemStatus = await _itemService.GetItemBorrowStatusAsync(request.ItemId);

            if (itemStatus == null)
            {
                return NotFound($"{request.ItemId} is not checked out");
            }

            var member = await _memberService.GetMemberbyMemberIdAsync(request.MemberId);

            if (member == null)
            {
                return NotFound(MessageHelper<Member>.NotFound(request.MemberId));
            }

            await _transactionService.RenewItemTransactionAsync(request.ItemId, itemStatus, member);

            return Ok(MessageHelper<Transaction>.Success());
        }

        [HttpPost]
        [Route("paymentOfFineTransaction")]
        public async Task<ActionResult> PaymentOfFineTransaction(TransactionPaymentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = await _memberService.GetMemberbyMemberIdAsync(request.MemberId);

            if (member == null)
            {
                return NotFound(MessageHelper<Member>.NotFound(request.MemberId));
            }

            await _transactionService.PaymentOfFineTransactionAsync(request.Amount, request.PaymentTypeId, member);

            return Ok(MessageHelper<Transaction>.Success());
        }
    }
}
