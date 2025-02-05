using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly LibraryInventoryDbContext _context;

        public ItemRepository(LibraryInventoryDbContext context)
        {
            _context = context;
        }

        public async Task<ItemEntity> AddItemAsync(ItemEntity item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemEntity?> GetItemAsync(int itemId)
        {
            return await _context.Items
                .Include(i => i.ItemDetail)
                .Include(i => i.ItemPolicy)
                .Include(i => i.ItemBorrowStatus)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);
        }

        public async Task<ItemBorrowStatusEntity?> GetItemBorrowStatusAsync(int itemId)
        {
            var item = await _context.Items
                .Include(i => i.ItemBorrowStatus)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);

            return item?.ItemBorrowStatus;
        }

        public async Task<ItemDetailEntity> GetItemDetailAsync(int itemId)
        {
            var item = await _context.Items
                .Include(i => i.ItemDetail)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);

            if (item == null)
            {
                throw new KeyNotFoundException($"Item {itemId} was not found");
            }

            if (item.ItemDetail == null)
            {
                throw new InvalidOperationException($"Item {itemId} does not have any details");
            }

            return item.ItemDetail;
        }

        public async Task<ItemPolicyEntity> GetItemPolicyAsync(int itemId)
        {
            var item = await _context.Items
                .Include(i => i.ItemPolicy)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);

            return item?.ItemPolicy;
        }

        public async Task<ItemPolicyEntity> CreateItemPolicyAsync(ItemPolicyEntity itemPolicy)
        {
            _context.ItemPolicies.Add(itemPolicy);
            await _context.SaveChangesAsync();
            return itemPolicy;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteItemPolicyAsync(int itemPolicyId)
        {
            var itemPolicy = await _context.ItemPolicies.FindAsync(itemPolicyId);

            if (itemPolicy != null)
            {
                _context.ItemPolicies.Remove(itemPolicy);
                await _context.SaveChangesAsync();
            }
        }

        public async Task InactivateItemAsync(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            if (item != null)
            {
                item.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ItemExistsAsync(int itemId)
        {
            return await _context.Items.AnyAsync(i => i.ItemId == itemId);
        }

        public async Task<IEnumerable<ItemEntity>> SearchItemsAsync(string searchTerm)
        {
            return await _context.Items
                .Where(i => i.ItemDetail.ItemTitle.Contains(searchTerm) || i.ItemDetail.ItemDescription.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<ItemEntity> UpdateItemAsync(ItemEntity item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemPolicyEntity> UpdateItemPolicyAsync(ItemPolicyEntity itemPolicy)
        {
            _context.ItemPolicies.Update(itemPolicy);
            await _context.SaveChangesAsync();
            return itemPolicy;
        }

        public async Task<ItemPolicyEntity?> GetPolicyForItemAsync(int itemId)
        {
            var item = await _context.Items
                .Include(i => i.ItemPolicy)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);

            return item?.ItemPolicy;
        }

        public async Task<bool> ItemPolicyExistsAsync(int itemPolicyId)
        {
            return await _context.ItemPolicies.AnyAsync(ip => ip.ItemPolicyId == itemPolicyId);
        }
    }
}
