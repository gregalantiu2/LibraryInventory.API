using LibraryInventory.Data.Entities;
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
            var policyType = await _context.ItemPolicies.FirstOrDefaultAsync(i => i.ItemPolicyId == item.ItemPolicyId);

            if (policyType == null)
            {
                throw new InvalidOperationException($"ItemPolicy {item.ItemPolicyId} not found");
            }

            item.ItemPolicy = policyType;

            var itemType = await _context.ItemTypes.FirstOrDefaultAsync(i => i.ItemTypeId == item.ItemTypeId);

            if (itemType == null)
            {
                throw new InvalidOperationException($"ItemType {item.ItemTypeId} not found");
            }

            item.ItemType = itemType;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<ItemEntity?> GetItemAsync(int itemId)
        {
            return await _context.Items
                .Include(i => i.ItemType)
                .Include(i => i.ItemPolicy)
                .ThenInclude(i => i.ItemFineOccurenceType)
                .Include(i => i.ItemBorrowStatus)
                .Include(i => i.ItemType)
                .ThenInclude(i => i.ItemTypeProperties)
                .FirstOrDefaultAsync(i => i.ItemId == itemId && i.ItemActive);
        }

        public async Task<ItemBorrowStatusEntity?> GetItemBorrowStatusAsync(int itemId)
        {
            var item = await _context.Items
                .Include(i => i.ItemBorrowStatus)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);

            return item?.ItemBorrowStatus;
        }

        public async Task<ItemPolicyEntity?> GetItemPolicyAsync(int itemPolicyId)
        {
            var policy = await _context.ItemPolicies
                .Include(p => p.ItemFineOccurenceType)
                .FirstOrDefaultAsync(i => i.ItemPolicyId == itemPolicyId);

            return policy;
        }

        public async Task<ItemPolicyEntity> AddtemPolicyAsync(ItemPolicyEntity itemPolicy)
        {
            var fineOccurence = await _context.ItemFineOccurenceTypes.FirstOrDefaultAsync(i => i.ItemFineOccurenceTypeId == itemPolicy.ItemFineOccurenceTypeId);

            if (fineOccurence == null)
            {
                throw new InvalidOperationException($"ItemFineOccurenceTypeId {itemPolicy.ItemFineOccurenceTypeId} not found");
            }

            itemPolicy.ItemFineOccurenceType = fineOccurence;

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
                item.ItemActive = false;
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
                .Where(i => i.ItemTitle.Contains(searchTerm) || i.ItemDescription.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<ItemEntity> UpdateItemAsync(ItemEntity updateItem)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == updateItem.ItemId);

            if (item == null)
            {
                throw new InvalidOperationException($"Item {updateItem.ItemId} not found");
            }

            var policyType = await _context.ItemPolicies.FirstOrDefaultAsync(i => i.ItemPolicyId == item.ItemPolicyId);

            if (policyType == null)
            {
                throw new InvalidOperationException($"ItemPolicy {item.ItemPolicyId} not found");
            }

            var itemType = await _context.ItemTypes.FirstOrDefaultAsync(i => i.ItemTypeId == item.ItemTypeId);

            if (itemType == null)
            {
                throw new InvalidOperationException($"ItemType {item.ItemTypeId} not found");
            }

            item.ItemType = itemType;
            item.ItemPolicy = policyType;
            item.ItemTitle = updateItem.ItemTitle;
            item.ItemDescription = updateItem.ItemDescription;
            item.ItemLocation = updateItem.ItemLocation;

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemPolicyEntity> UpdateItemPolicyAsync(ItemPolicyEntity itemPolicy)
        {
            var currentPolicy = await _context.ItemPolicies.FirstOrDefaultAsync(i => i.ItemPolicyId == itemPolicy.ItemPolicyId);

            if (currentPolicy == null)
            {
                throw new InvalidOperationException($"ItemPolicy {itemPolicy.ItemPolicyId} not found");
            }

            var fineOccurence = await _context.ItemFineOccurenceTypes.FirstOrDefaultAsync(i => i.ItemFineOccurenceTypeId == itemPolicy.ItemFineOccurenceTypeId);

            if (fineOccurence == null)
            {
                throw new InvalidOperationException($"ItemFineOccurenceType {itemPolicy.ItemFineOccurenceTypeId} not found");
            }

            currentPolicy.ItemPolicyName = itemPolicy.ItemPolicyName;
            currentPolicy.FineAmount = itemPolicy.FineAmount;
            currentPolicy.AllowedToCheckout = itemPolicy.AllowedToCheckout;
            currentPolicy.MaxRenewalsAllowed = itemPolicy.MaxRenewalsAllowed;
            currentPolicy.CheckoutDays = itemPolicy.CheckoutDays;
            currentPolicy.ItemFineOccurenceTypeId = fineOccurence.ItemFineOccurenceTypeId;

            await _context.SaveChangesAsync();
            return currentPolicy;
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
