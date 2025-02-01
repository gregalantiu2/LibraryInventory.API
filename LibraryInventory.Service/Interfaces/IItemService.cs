using LibraryInventory.Model.Models.Product;

namespace LibraryInventory.Service.Interfaces
{
    public interface IItemService<T>
    {
        IEnumerable<Item> SearchItems(string[] itemTypes, string[] propertyNames, string searchTerm);
        T AddItem(T item);
        T UpdateItem(T item);
        void DeleteItem(int itemId);
        T GetItem(T item);
    }
}
