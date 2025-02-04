using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Repositories.Interfaces;

namespace LibraryInventory.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<TransactionEntity> GetTransactionAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionEntity>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionEntity>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionEntity>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionTypeEntity>> GetTransactionTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task PaymentOnOwedAmount(decimal amount, string memberId)
        {
            throw new NotImplementedException();
        }

        public Task PerformCheckout(int itemId, string memberId)
        {
            throw new NotImplementedException();
        }

        public Task PerformRenewal(int itemId, string memberId)
        {
            throw new NotImplementedException();
        }

        public Task PerformReturn(int itemId, string memberId)
        {
            throw new NotImplementedException();
        }
    }
}
