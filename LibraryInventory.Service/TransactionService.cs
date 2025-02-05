using LibraryInventory.Data.Entities;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.TransactionModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public class TransactionService : ITransactionService
    {
        public Task CheckoutItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }

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

        public Task PaymentOfFineTransaction(decimal amount, Member member)
        {
            throw new NotImplementedException();
        }

        public Task RenewItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }

        public Task ReturnItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }
    }
}
