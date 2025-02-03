using LibraryInventory.Model.TransactionModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionAsync(string transactionId);
        Task<IEnumerable<Transaction>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null);
        Task<IEnumerable<Transaction>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionType>> GetTransactionTypesAsync();
        Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null);
        Task PerformCheckout(int itemId, string memberId);
        Task PerformReturn(int itemId, string memberId);
        Task PerformRenewal(int itemId, string memberId);
        Task PaymentOnOwedAmount(decimal amount, string memberId);

        //Sell
        //Buy
    }
}
