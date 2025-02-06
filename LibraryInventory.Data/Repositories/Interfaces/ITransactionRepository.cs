using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Model.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<TransactionEntity> GetTransactionAsync(int transactionId);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null);
        Task<IEnumerable<TransactionTypeEntity>> GetTransactionTypesAsync();
        Task<IEnumerable<TransactionEntity>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null);
        Task AddTransactionTypeAsync(TransactionTypeEntity transactionType);
        Task DeleteTransactionTypeAsync(int transactionTypeId);
        Task CreateTransactionAsync(TransactionEntity transaction);
        Task DeleteTransactionAsync(int transactionId);
        Task<TransactionTypeEntity> GetTransactionTypesByNameAsync(string transactionType);
        Task PaymentOfFineTransactionAsync(TransactionEntity transaction, MemberEntity member);
        Task CheckoutItemTransactionAsync(TransactionEntity transaction, ItemEntity item, MemberEntity member, ItemBorrowStatusEntity status);
    }
}
