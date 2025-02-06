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
        private readonly IMemberRepository _memberRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, 
                                    IMapper mapper,     
                                    IMemberRepository memberRepository,
                                    IItemRepository itemRepository)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _memberRepository = memberRepository;
            _itemRepository = itemRepository;
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
            if (item.ItemId == null || member.MemberId == null)
            {
                throw new ArgumentException("Item or member is null.");
            }

            if (item.ItemBorrowStatus != null)
            { 
                throw new ArgumentException("Item is already checked out.");            
            }

            if (item.ItemPolicy == null || item.ItemPolicy.AllowedToCheckout == false || item.ItemPolicy.CheckoutDays == null)
            {
                throw new ArgumentException("Item is not allowed to be checked out.");
            }

            var memberEntity = await _memberRepository.GetMemberbyMemberIdAsync(member.MemberId);

            var status = new ItemBorrowStatus(true, DateTime.Now, DateTime.Now.AddDays((double)item.ItemPolicy.CheckoutDays), 0, 0, memberEntity.MemberKeyId);

            //Creating the transaction
            var transaction = new Transaction(new TransactionType("Checkout"), DateTime.Now, item.ItemId, null, memberId: member.MemberId);

            //Mapping 
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);
            var statusEntity = _mapper.Map<ItemBorrowStatusEntity>(status);
            statusEntity.MemberKeyId = memberEntity.MemberKeyId;
            statusEntity.ItemId = (int)item.ItemId!;

            await _transactionRepository.CheckoutItemTransactionAsync(transactionEntity, statusEntity);
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
            var paymentType = new TransactionPaymentType(paymentTypeId);
            var payment = new TransactionPayment(amount, paymentType);
            var transaction = new Transaction(new TransactionType("Payment"), DateTime.Now, null);

            await _transactionRepository.PaymentOfFineTransactionAsync(_mapper.Map<TransactionEntity>(transaction), _mapper.Map<TransactionPaymentEntity>(payment), _mapper.Map<MemberEntity>(member));
        }

        public async Task RenewItemTransactionAsync(int itemId, ItemBorrowStatus itemStatus, Member member)
        {
            if (itemStatus == null || !itemStatus.IsCheckedOut)
            {
                throw new ArgumentException($"Item is not marked as checked out");
            }

            if (itemStatus.MemberkeyId != member.MemberKeyId)
            {
                throw new ArgumentException($"{itemId} is checked out by a different member");
            }

            var itemPolicy = await _itemRepository.GetPolicyForItemAsync(itemId);

            if (itemPolicy == null)
            {
                throw new ArgumentException($"No policy assigned for item {itemId}");
            }

            if (itemStatus.RenewedCount >= itemPolicy.MaxRenewalsAllowed)
            {
                throw new ArgumentException($"Item {itemId} has reached it's max renewal count for member {member.MemberId}");
            }

            // Changing status details for a renewal
            itemStatus.DueBack = itemStatus.DueBack?.AddDays((double)itemPolicy.CheckoutDays);
            itemStatus.RenewedCount++;

            // Creating the transaction
            var transaction = new Transaction(new TransactionType("Renew"), DateTime.Now, itemId, null, memberId: member.MemberId);

            // Mapping to entities
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);
            var itemStatusEntity = _mapper.Map<ItemBorrowStatusEntity>(itemStatus);

            await _transactionRepository.RenewItemTransactionAsync(transactionEntity, itemStatusEntity);
        }

        public async Task ReturnItemTransactionAsync(int itemId, Member member)
        {
            var borrowStatus = await _itemRepository.GetItemBorrowStatusAsync(itemId);

            if (borrowStatus == null)
            {
                throw new ArgumentException($"Item is not marked as checked out");
            }

            // Creating the transaction
            var transactionType = _mapper.Map<TransactionType>(await _transactionRepository.GetTransactionTypesByNameAsync("Return"));
            var transaction = new Transaction(transactionType, DateTime.Now, itemId, null, memberId: member.MemberId);

            // Mapping to entities
            var transactionEntity = _mapper.Map<TransactionEntity>(transaction);

            await _transactionRepository.ReturnItemTransactionAsync(transactionEntity, borrowStatus.ItemBorrowStatusId);
        }
    }
}
