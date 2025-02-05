using LibraryInventory.Model.ItemModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> SearchItemsAsync(string searchTerm);
        Task<Item> AddItemAsync(Item Item);
        Task<Item> UpdateItemAsync(Item Item);
        Task InactivateItemAsync(int itemId);
        Task DeleteItemAsync(int itemId);
        Task<Item> GetItemAsync(int itemId);
        Task<bool> ItemExistsAsync(int itemId);
        Task<ItemBorrowStatus> GetItemBorrowStatusAsync(int itemId);
        Task<ItemPolicy> GetPolicyForItemAsync(int itemId);
        Task<ItemPolicy> GetItemPolicyAsync(int itemId);
        Task<ItemPolicy> UpdateItemPolicyAsync(ItemPolicy itemPolicy);
        Task<ItemPolicy> CreateItemPolicyAsync(ItemPolicy itemPolicy);
        Task DeleteItemPolicyAsync(int itemPolicyId);
        Task<bool> ItemPolicyExistsAsync(int itemPolicyId);
    }
}