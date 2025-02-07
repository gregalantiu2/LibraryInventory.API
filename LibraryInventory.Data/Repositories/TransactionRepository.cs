using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.TransactionModels;
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
            if (daysToLookBack != null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return await _context.Transactions
                            .Include(t => t.TransactionType)
                            .Include(t => t.Item)
                            .Include(t => t.Member)
                            .Where(t => t.ItemId == itemId && t.CreatedDate >= pastDate).ToListAsync();
            }

            return await _context.Transactions
                        .Include(t => t.TransactionType)
                        .Include(t => t.Item)
                        .Include(t => t.Member)
                        .Where(t => t.ItemId == itemId).ToListAsync();
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null)
        {
            if (daysToLookBack != null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return await _context.Transactions
                            .Include(t => t.TransactionType)
                            .Include(t => t.Item)
                            .Include(t => t.Member)
                            .Where(t => t.MemberId == memberId && t.CreatedDate >= pastDate).ToListAsync();
            }

            return await _context.Transactions
                        .Include(t => t.TransactionType)
                        .Include(t => t.Item)
                        .Include(t => t.Member)
                        .Where(t => t.MemberId == memberId).ToListAsync();
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null)
        {

            if (daysToLookBack != null)
            {
                var pastDate = DateTime.UtcNow.AddDays(-daysToLookBack.Value);

                return await _context.Transactions
                    .Include(t => t.TransactionType)
                    .Include(t => t.Item)
                    .Include(t => t.Member)
                    .Where(t => t.TransactionTypeId == transactionTypeId && t.CreatedDate >= pastDate).ToListAsync();
            }

            return await _context.Transactions
                .Include(t => t.TransactionType)
                .Include(t => t.Item)
                .Include(t => t.Member)
                .Where(t => t.TransactionTypeId == transactionTypeId).ToListAsync();
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

        public async Task PaymentOfFineTransactionAsync(TransactionEntity transaction, TransactionPaymentEntity transactionPayment, MemberEntity member)
        {
            using (var wrapTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var transactionType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TransactionTypeName == "Payment");

                    if (transactionType == null)
                    {
                        throw new InvalidOperationException("Transaction type Payment not found");
                    }

                    transaction.TransactionType = transactionType;

                    var transactionPaymentType = await _context.TransactionPaymentTypes.FindAsync(transactionPayment.TransactionPaymentTypeId);

                    if(transactionPaymentType == null)
                    {
                        throw new InvalidOperationException($"{transactionPayment.TransactionPaymentTypeId} Transaction payment type not found");
                    }

                    var currentMember = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == member.MemberId);

                    if (currentMember == null)
                    {
                        throw new InvalidOperationException($"Member {member.MemberId} not found");
                    }

                    currentMember.FineAmountOwed = member.FineAmountOwed;

                    transaction.TransactionType = transactionType;
                    _context.Transactions.Add(transaction);

                    await _context.SaveChangesAsync();

                    transactionPayment.TransactionId = transaction.TransactionId;

                    transactionPayment.TransactionPaymentType = transactionPaymentType;
                    _context.TransactionPayments.Add(transactionPayment);

                    _context.Members.Update(currentMember);

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

        public async Task CheckoutItemTransactionAsync(TransactionEntity transaction, ItemBorrowStatusEntity status)
        {
            using (var wrapTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var transactionType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TransactionTypeName == "Checkout");
                    
                    if (transactionType == null)
                    {
                        throw new InvalidOperationException("Transaction type Checkout not found");
                    }

                    transaction.TransactionType = transactionType;
                    _context.Transactions.Add(transaction);

                    _context.ItemBorrowStatuses.Add(status);

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

        public async Task ReturnItemTransactionAsync(TransactionEntity transaction, int itemBorrowStatusId)
        {
            using (var wrapTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var transactionType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TransactionTypeName == "Return");

                    if (transactionType == null)
                    {
                        throw new InvalidOperationException("Transaction type Return not found");
                    }

                    transaction.TransactionType = transactionType;
                    _context.Transactions.Add(transaction);

                    var borrowStatus = await _context.ItemBorrowStatuses.FindAsync(itemBorrowStatusId);

                    if (borrowStatus == null)
                    {
                        throw new InvalidOperationException($"Item borrow status {itemBorrowStatusId} not found");
                    }

                    _context.ItemBorrowStatuses.Remove(borrowStatus);

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

        public async Task RenewItemTransactionAsync(TransactionEntity transaction, ItemBorrowStatusEntity itemStatus)
        {
            using (var wrapTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Transactions.Add(transaction);

                    var existingBorrowStatus = await _context.ItemBorrowStatuses.FindAsync(itemStatus.ItemBorrowStatusId);

                    if(existingBorrowStatus == null)
                    {
                        throw new InvalidOperationException($"Item borrow status {itemStatus.ItemBorrowStatusId} not found");
                    }

                    existingBorrowStatus.DueBack = itemStatus.DueBack;
                    existingBorrowStatus.RenewedCount = itemStatus.RenewedCount;

                    _context.ItemBorrowStatuses.Update(existingBorrowStatus);

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
