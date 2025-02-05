using AutoMapper;
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
        private readonly IItemRepository _itemRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository
                                    ,IItemRepository itemRepository
                                    ,IMemberRepository memberRepository
                                    ,IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _itemRepository = itemRepository;
            _memberRepository = memberRepository;
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

        public async Task CheckoutItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }

        public async Task PaymentOfFineTransaction(decimal amount, Member member)
        {
            throw new NotImplementedException();
        }

        public async Task RenewItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }

        public async Task ReturnItemTransaction(Item item, Member member)
        {
            throw new NotImplementedException();
        }
    }
}
