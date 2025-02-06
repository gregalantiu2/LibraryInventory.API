using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Data.Entities.Person;

namespace LibraryInventory.Data.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> SearchItemsAsync(string searchTerm);
        Task<ItemEntity> AddItemAsync(ItemEntity Item);
        Task<ItemEntity> UpdateItemAsync(ItemEntity Item);
        Task InactivateItemAsync(int itemId);
        Task DeleteItemAsync(int itemId);
        Task<ItemEntity?> GetItemAsync(int itemId);
        Task<ItemPolicyEntity?> GetPolicyForItemAsync(int itemId);
        Task<bool> ItemPolicyExistsAsync(int itemPolicyId);
        Task<bool> ItemExistsAsync(int itemId);
        Task<ItemBorrowStatusEntity?> GetItemBorrowStatusAsync(int itemId);
        Task<ItemPolicyEntity> AddtemPolicyAsync(ItemPolicyEntity itemPolicy);
        Task<ItemPolicyEntity> UpdateItemPolicyAsync(ItemPolicyEntity itemPolicy);
        Task DeleteItemPolicyAsync(int itemPolicyId);
        Task<ItemPolicyEntity?> GetItemPolicyAsync(int itemId);
    }
}
