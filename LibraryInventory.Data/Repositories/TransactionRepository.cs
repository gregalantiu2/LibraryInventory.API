using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LibraryInventoryDbContext _context;

        public TransactionRepository(LibraryInventoryDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionType(TransactionTypeEntity transactionType)
        {
            _context.TransactionTypes.Add(transactionType);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTransaction(TransactionEntity transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransaction(int transactionId)
        {
            var transactionEntity = await _context.Transactions.FindAsync(transactionId);

            if (transactionEntity != null)
            {
                _context.Transactions.Remove(transactionEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransactionType(int transactionTypeId)
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
    }
}
