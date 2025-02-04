using LibraryInventory.Data.Entities;
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
        Task PerformCheckout(int itemId, string memberId);
        Task PerformReturn(int itemId, string memberId);
        Task PerformRenewal(int itemId, string memberId);
        Task PaymentOnOwedAmount(decimal amount, string memberId);
    }
}
