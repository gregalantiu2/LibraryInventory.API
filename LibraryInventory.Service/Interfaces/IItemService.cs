using LibraryInventory.Model.Models.Person;
using LibraryInventory.Model.Models.Product;

namespace LibraryInventory.Service.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> SearchItemsAsync(string searchTerm);
        Task<Item> AddItemAsync(Item Item);
        Task<Item> UpdateItemAsync(Item Item);
        Task InactivateItemAsync(string ItemId);
        Task DeleteItemAsync(string ItemId);
        Task<Item> GetItemAsync(string ItemId);
        Task<bool> ItemExistsAsync(string ItemId);
        Task<ItemBorrowStatus> GetItemBorrowStatusAsync(int itemId);
        Task<ItemDetail> GetItemDetailAsync(int itemId);
        Task<ItemPolicy> GetItemPolicyAsync(int itemId);
    }
}