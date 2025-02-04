using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Task<ItemEntity> AddItemAsync(ItemEntity Item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemEntity> GetItemAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemBorrowStatusEntity> GetItemBorrowStatusAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDetailEntity> GetItemDetailAsync(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemPolicyEntity> GetItemPolicyAsync(int itemId)
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

        public Task<IEnumerable<ItemEntity>> SearchItemsAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<ItemEntity> UpdateItemAsync(ItemEntity Item)
        {
            throw new NotImplementedException();
        }
    }
}
