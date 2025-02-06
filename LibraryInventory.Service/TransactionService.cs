using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.TransactionModels;
using LibraryInventory.Service.Interfaces;
using Member = LibraryInventory.Model.PersonModels.Member;
using Transaction = LibraryInventory.Model.TransactionModels.Transaction;

namespace LibraryInventory.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> GetTransactionAsync(int transactionId)
        {
            var transaction = await _transactionRepository.GetTransactionAsync(transactionId);
            return _mapper.Map<Transaction>(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByItemAsync(int itemId, int? daysToLookBack = null)
        {
            var transactions = await _transactionRepository.GetTransactionsByItemAsync(itemId, daysToLookBack);
            return _mapper.Map<IEnumerable<Transaction>>(transactions);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByMemberAsync(int memberId, int? daysToLookBack = null)
        {
            var transactions = await _transactionRepository.GetTransactionsByMemberAsync(memberId, daysToLookBack);
            return _mapper.Map<IEnumerable<Transaction>>(transactions);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByTypeAsync(int transactionTypeId, int? daysToLookBack = null)
        {
            var transactions = await _transactionRepository.GetTransactionsByTypeAsync(transactionTypeId, daysToLookBack);
            return _mapper.Map<IEnumerable<Transaction>>(transactions);
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypesAsync()
        {
            var transactionTypes = await _transactionRepository.GetTransactionTypesAsync();
            return _mapper.Map<IEnumerable<TransactionType>>(transactionTypes);
        }

        public async Task CheckoutItemTransactionAsync(Item item, Member member)
        {
            if (item.ItemBorrowStatus != null)
            { 
                throw new ArgumentException("Item is already checked out.");            
            }

            if (item.ItemPolicy == null || item.ItemPolicy.AllowedToCheckout == false || item.ItemPolicy.CheckoutDays == null)
            {
                throw new ArgumentException("Item is not allowed to be checked out.");
            }

            var status = new ItemBorrowStatus(true, DateTime.Now, DateTime.Now.AddDays((double)item.ItemPolicy.CheckoutDays), 0, 0, member.MemberId!);

            //Creating the transaction
            var transactionType = _mapper.Map<TransactionType>(await _transactionRepository.GetTransactionTypesByNameAsync("Checkout"));
            var transaction = new Transaction(transactionType, DateTime.Now, item.ItemId, null, memberId: member.MemberId);

            //Mapping 
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);
            var itemEntity = _mapper.Map<ItemEntity>(item);
            var memberEntity = _mapper.Map<MemberEntity>(member);
            var statusEntity = _mapper.Map<ItemBorrowStatusEntity>(status);

            await _transactionRepository.CheckoutItemTransactionAsync(transactionEntity, itemEntity, memberEntity, statusEntity);
        }

        public async Task PaymentOfFineTransactionAsync(decimal amount, int paymentTypeId, Member member)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }

            if (amount > member.FineAmountOwed)
            {
                throw new ArgumentException("Amount must be less than or equal to the fine amount owed.");
            }

            member.FineAmountOwed -= amount;

            // Creating the payment transaction
            var transactionType = _mapper.Map<TransactionType>(await _transactionRepository.GetTransactionTypesByNameAsync("Payment"));
            var paymentType = new TransactionPaymentType(paymentTypeId);
            var payment = new TransactionPayment(amount, paymentType);
            var transaction = new Transaction(transactionType, DateTime.Now, null, transactionPayments: new List<TransactionPayment>() { payment });

            await _transactionRepository.PaymentOfFineTransactionAsync(_mapper.Map<TransactionEntity>(transaction), _mapper.Map<MemberEntity>(member));
        }

        public async Task RenewItemTransactionAsync(Item item, Member member)
        {
            if (item.ItemBorrowStatus == null || !item.ItemBorrowStatus.IsCheckedOut)
            {
                throw new ArgumentException($"{item.ItemId} is not marked as checked out");
            }

            if (item.ItemBorrowStatus.MemberId != member.MemberId)
            {
                throw new ArgumentException($"{item.ItemId} is checked out by a different member {item.ItemBorrowStatus.MemberId}");
            }

            if (item.ItemPolicy == null)
            {
                throw new ArgumentException($"No policy assigned for item {item.ItemId}");
            }

            if (item.ItemBorrowStatus.RenewedCount >= item.ItemPolicy.MaxRenewalsAllowed)
            {
                throw new ArgumentException($"Item {item.ItemId} has reached it's max renewal count for member {member.MemberId}");
            }

            item.ItemBorrowStatus.DueBack = item.ItemBorrowStatus.DueBack?.AddDays((double)item.ItemPolicy.CheckoutDays);
            item.ItemBorrowStatus.RenewedCount++;

            // Creating the transaction
            var transactionType = _mapper.Map<TransactionType>(await _transactionRepository.GetTransactionTypesByNameAsync("Renew"));
            var transaction = new Transaction(transactionType, DateTime.Now, item.ItemId, null, memberId: member.MemberId);

            // Mapping to entities
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);
            var itemEntity = _mapper.Map<ItemEntity>(item);

            await _transactionRepository.RenewItemTransactionAsync(transactionEntity, itemEntity);
        }

        public async Task ReturnItemTransactionAsync(Item item, Member member)
        {
            if (item.ItemBorrowStatus == null)
            {
                throw new ArgumentException($"{item.ItemId} is not marked as checked out");
            }

            int? itemBorrowStatusId = item.ItemBorrowStatus.ItemBorrowStatusId;
            item.ItemBorrowStatus = null;

            // Creating the transaction
            var transactionType = _mapper.Map<TransactionType>(await _transactionRepository.GetTransactionTypesByNameAsync("Return"));
            var transaction = new Transaction(transactionType, DateTime.Now, item.ItemId, null, memberId: member.MemberId);

            // Mapping to entities
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);
            var itemEntity = _mapper.Map<ItemEntity>(item);
            var memberEntity = _mapper.Map<MemberEntity>(member);

            await _transactionRepository.ReturnItemTransactionAsync(transactionEntity, itemEntity, memberEntity, itemBorrowStatusId);
        }
    }
}
