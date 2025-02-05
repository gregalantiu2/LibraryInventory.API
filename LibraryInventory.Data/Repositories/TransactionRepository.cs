﻿using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.TransactionModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LibraryInventoryDbContext _context;
        private readonly IMemberRepository _memberRepository;

        public TransactionRepository(LibraryInventoryDbContext context, IMemberRepository memberRepository)
        {
            _context = context;
            _memberRepository = memberRepository;
        }

        public async Task AddTransactionType(TransactionTypeEntity transactionType)
        {
            _context.TransactionTypes.Add(transactionType);
            await _context.SaveChangesAsync();
        }

        public Task AddTransactionTypeAsync(TransactionTypeEntity transactionType)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTransactionAsync(TransactionEntity transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int transactionId)
        {
            var transactionEntity = await _context.Transactions.FindAsync(transactionId);

            if (transactionEntity != null)
            {
                _context.Transactions.Remove(transactionEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransactionTypeAsync(int transactionTypeId)
        {
            var transactionType = await _context.TransactionTypes.FindAsync(transactionTypeId);

            if (transactionType != null)
            {
                _context.TransactionTypes.Remove(transactionType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TransactionEntity> GetTransactionAsync(int transactionId)
        {
            var transaction = await _context.Transactions
                    .Include(t => t.TransactionType)
                    .Include(t => t.Item)
                    .Include(t => t.Member)
                    .FirstOrDefaultAsync(t => t.TransactionId == transactionId);

            if (transaction == null)
            {
                throw new InvalidOperationException($"Transaction {transactionId} not found");
            }

            return transaction;
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null)
        {
            var query = _context.Transactions
                .Include(t => t.TransactionType)
                .Include(t => t.Item)
                .Include(t => t.Member)
                .Where(t => t.ItemId == itemId);

            if (daysToLookBack == null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return _context.Transactions
                            .Include(t => t.TransactionType)
                            .Include(t => t.Item)
                            .Include(t => t.Member)
                            .Where(t => t.ItemId == itemId && t.CreatedDate >= pastDate);
            }

            return _context.Transactions
                        .Include(t => t.TransactionType)
                        .Include(t => t.Item)
                        .Include(t => t.Member)
                        .Where(t => t.ItemId == itemId);
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null)
        {
            if (daysToLookBack == null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return _context.Transactions
                            .Include(t => t.TransactionType)
                            .Include(t => t.Item)
                            .Include(t => t.Member)
                            .Where(t => t.MemberId == memberId && t.CreatedDate >= pastDate);
            }

            return _context.Transactions
                        .Include(t => t.TransactionType)
                        .Include(t => t.Item)
                        .Include(t => t.Member)
                        .Where(t => t.MemberId == memberId);
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null)
        {

            if (daysToLookBack == null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return _context.Transactions
                    .Include(t => t.TransactionType)
                    .Include(t => t.Item)
                    .Include(t => t.Member)
                    .Where(t => t.TransactionTypeId == transactionTypeId && t.CreatedDate >= pastDate);
            }

            return _context.Transactions
                .Include(t => t.TransactionType)
                .Include(t => t.Item)
                .Include(t => t.Member)
                .Where(t => t.TransactionTypeId == transactionTypeId);
        }

        public async Task<IEnumerable<TransactionTypeEntity>> GetTransactionTypesAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public async Task<TransactionTypeEntity> GetTransactionTypesByNameAsync(string transactionType)
        {
            var type = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TransactionTypeName == transactionType);

            if (type == null)
            {
                throw new InvalidOperationException($"Transaction type {transactionType} not found");
            }

            return type;
        }

        public async Task PaymentOfFineTransactionAsync(TransactionEntity transaction, MemberEntity member)
        {
            using (var wrapTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Transactions.Add(transaction);
                    await _memberRepository.UpdateMemberAsync(member);
                    await _context.SaveChangesAsync();

                    await wrapTransaction.CommitAsync();
                }
                catch
                {
                    await wrapTransaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
