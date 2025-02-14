﻿using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            var result = await _itemRepository.AddItemAsync(_mapper.Map<ItemEntity>(item));
            return _mapper.Map<Item>(result);
        }

        public async Task<ItemPolicy> AddtemPolicyAsync(ItemPolicy itemPolicy)
        {
            var result = await _itemRepository.AddtemPolicyAsync(_mapper.Map<ItemPolicyEntity>(itemPolicy));
            return _mapper.Map<ItemPolicy>(result);
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _itemRepository.DeleteItemAsync(itemId);
        }

        public async Task DeleteItemPolicyAsync(int itemPolicyId)
        {
            await _itemRepository.DeleteItemPolicyAsync(itemPolicyId);
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            var result = await _itemRepository.GetItemAsync(itemId);

            var fineOccurenceType = new ItemFineOccurenceType(result.ItemPolicy.ItemFineOccurenceType.ItemFineOccurenceTypeId);
            fineOccurenceType.ItemFineOccurenceTypeDescription = result.ItemPolicy.ItemFineOccurenceType.ItemFineOccurenceTypeDescription;

            var itemType = new ItemType(result.ItemType.ItemTypeId);

            var itemPolicy = new ItemPolicy(result.ItemPolicy.ItemPolicyName,
                                            result.ItemPolicy.AllowedToCheckout
                                            , result.ItemPolicy.MaxRenewalsAllowed
                                            , result.ItemPolicy.CheckoutDays
                                            , result.ItemPolicy.FineAmount
                                            , fineOccurenceType
                                            , result.ItemPolicy.ItemPolicyId);

            if (result.ItemBorrowStatus != null)
            {
                var status = new ItemBorrowStatus(result.ItemBorrowStatus.CheckedOutDate.HasValue ? true : false
                                  , result.ItemBorrowStatus.CheckedOutDate
                                  , result.ItemBorrowStatus.DueBack
                                  , result.ItemBorrowStatus.RenewedCount
                                  , result.ItemBorrowStatus.FineAmountAccrued
                                  , result.ItemBorrowStatus.MemberKeyId);

                return new Item(result.ItemTitle, result.ItemDescription, itemType, itemPolicy, status, null, result.ItemId);
            }

            return new Item(result.ItemTitle, result.ItemDescription, itemType, itemPolicy, null, null, result.ItemId);
        }

        public async Task<ItemBorrowStatus> GetItemBorrowStatusAsync(int itemId)
        {
            var result = await _itemRepository.GetItemBorrowStatusAsync(itemId);
            return _mapper.Map<ItemBorrowStatus>(result);
        }

        public async Task<ItemPolicy> GetItemPolicyAsync(int itemId)
        {
            var result = await _itemRepository.GetItemPolicyAsync(itemId);
            return _mapper.Map<ItemPolicy>(result);
        }

        public async Task<ItemPolicy> GetPolicyForItemAsync(int itemId)
        {
            var result = await _itemRepository.GetPolicyForItemAsync(itemId);
            return _mapper.Map<ItemPolicy>(result);
        }

        public async Task InactivateItemAsync(int itemId)
        {
            await _itemRepository.InactivateItemAsync(itemId);
        }

        public async Task<bool> ItemExistsAsync(int itemId)
        {
            return await _itemRepository.ItemExistsAsync(itemId);
        }

        public async Task<bool> ItemPolicyExistsAsync(int itemPolicyId)
        {
            return await _itemRepository.ItemPolicyExistsAsync(itemPolicyId);
        }

        public async Task<IEnumerable<Item>> SearchItemsAsync(string searchTerm)
        {
            var result = await _itemRepository.SearchItemsAsync(searchTerm);
            return _mapper.Map<IEnumerable<Item>>(result);
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            var result = await _itemRepository.UpdateItemAsync(_mapper.Map<ItemEntity>(item));
            return _mapper.Map<Item>(result);
        }

        public async Task<ItemPolicy> UpdateItemPolicyAsync(ItemPolicy itemPolicy)
        {
            var result = await _itemRepository.UpdateItemPolicyAsync(_mapper.Map<ItemPolicyEntity>(itemPolicy));
            return _mapper.Map<ItemPolicy>(result);
        }
    }
}
