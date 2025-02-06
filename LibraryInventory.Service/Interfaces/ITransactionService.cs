using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.TransactionModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null);
        Task<IEnumerable<Transaction>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionType>> GetTransactionTypesAsync();
        Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null);
        Task CheckoutItemTransactionAsync(Item item, Member member);
        Task ReturnItemTransactionAsync(Item item, Member member);
        Task RenewItemTransactionAsync(Item item, Member member);
        Task PaymentOfFineTransactionAsync(decimal amount, int paymentTypeId);
    }
}
