using LibraryInventory.API.Extensions;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Transactions;

namespace LibraryInventory.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("getTransaction/{transactionId}")]
        public async Task<ActionResult> GetTransaction(int transactionId)
        {
            var transaction = await _transactionService.GetTransactionAsync(transactionId);

            if (transaction == null)
            {
                return NotFound(MessageHelper<Transaction>.NotFound(transactionId.ToString()));
            }

            return Ok(transaction);
        }

        [HttpGet]
        [Route("getTransactionsByMember/{memberId}")]
        public async Task<ActionResult> GetTransactionsByMember(int memberId, int? daysToLookBack = null)
        {
            var transactions = await _transactionService.GetTransactionsByMemberAsync(memberId, daysToLookBack);

            return Ok(transactions);
        }

        [HttpGet]
        [Route("getTransactionsByItem/{itemId}")]
        public async Task<ActionResult> GetTransactionsByItem(int itemId, int? daysToLookBack = null)
        {
            var transactions = await _transactionService.GetTransactionsByItemAsync(itemId, daysToLookBack);

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
        public async Task<ActionResult> GetTransactionsByType(int transactionTypeId, int? daysToLookBack = null)
        {
            var transactions = await _transactionService.GetTransactionsByTypeAsync(transactionTypeId, daysToLookBack);

            return Ok(transactions);
        }

        [HttpPost]
        [Route("performCheckout")]
        public async Task<ActionResult> PerformCheckout(int itemId, string memberId)
        {
            await _transactionService.PerformCheckout(itemId, memberId);

            return NoContent();
        }

        [HttpPost]
        [Route("performReturn")]
        public async Task<ActionResult> PerformReturn(int itemId, string memberId)
        {
            await _transactionService.PerformReturn(itemId, memberId);

            return NoContent();
        }

        [HttpPost]
        [Route("performRenewal")]
        public async Task<ActionResult> PerformRenewal(int itemId, string memberId)
        {
            await _transactionService.PerformRenewal(itemId, memberId);

            return NoContent();
        }

        [HttpPost]
        [Route("paymentOnOwedAmount")]
        public async Task<ActionResult> PaymentOnOwedAmount(decimal amount, string memberId)
        {
            await _transactionService.PaymentOnOwedAmount(amount, memberId);

            return NoContent();
        }
    }
}
