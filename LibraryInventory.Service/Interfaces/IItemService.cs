using LibraryInventory.Model.Models.Product;

namespace LibraryInventory.Service.Interfaces
{
    public interface IItemService
    {
        IEnumerable<Item> SearchItems(string[] itemTypes, string[] propertyNames, string searchTerm);
        Item AddItem(Item item);
        Item UpdateItem(Item item);
        void DeleteItem(int itemId);
        Item GetItem(int itemId);
        ItemBorrowStatus GetItemBorrowStatus(int itemId);
        ItemDetail GetItemDetail(int itemId);
        ItemPolicy GetItemPolicy(int itemId);
    }
}