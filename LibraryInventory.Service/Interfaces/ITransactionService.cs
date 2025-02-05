using LibraryInventory.Data.Entities;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.TransactionModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionEntity> GetTransactionAsync(int transactionId);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionTypeEntity>> GetTransactionTypesAsync();
        Task<IEnumerable<TransactionEntity>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null);
        Task CheckoutItemTransaction(Item item, Member member);
        Task ReturnItemTransaction(Item item, Member member);
        Task RenewItemTransaction(Item item, Member member);
        Task PaymentOfFineTransaction(decimal amount, Member member);
    }
}
