﻿using LibraryInventory.Model.ItemModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public class ItemService : IItemService
    {
        public Task<Item> AddItemAsync(Item Item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemBorrowStatus> GetItemBorrowStatusAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDetail> GetItemDetailAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemPolicy> GetItemPolicyAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task InactivateItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ItemExistsAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> SearchItemsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItemAsync(Item Item)
        {
            throw new NotImplementedException();
        }
    }
}
