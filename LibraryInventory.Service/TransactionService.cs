﻿using LibraryInventory.Model.TransactionModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public class TransactionService : ITransactionService
    {
        public Task<Transaction> GetTransactionAsync(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionType>> GetTransactionTypesAsync()
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
