using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;

namespace LibraryInventory.Data.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> SearchItemsAsync(string searchTerm);
        Task<ItemEntity> AddItemAsync(ItemEntity Item);
        Task<ItemEntity> UpdateItemAsync(ItemEntity Item);
        Task InactivateItemAsync(int itemId);
        Task DeleteItemAsync(int itemId);
        Task<ItemEntity> GetItemAsync(int itemId);
        Task<bool> ItemExistsAsync(int itemId);
        Task<ItemBorrowStatusEntity> GetItemBorrowStatusAsync(int itemId);
        Task<ItemDetailEntity> GetItemDetailAsync(int itemId);
        Task<ItemPolicyEntity> GetItemPolicyAsync(int itemId);
    }
}
