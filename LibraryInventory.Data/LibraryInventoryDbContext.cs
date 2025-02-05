using LibraryInventory.Data.Audit.Interfaces;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LibraryInventory.Data
{
    public class LibraryInventoryDbContext : DbContext
    {
        private readonly IUserContext _userContext;

        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<ItemDetailEntity> ItemDetails { get; set; }
        public DbSet<ItemPolicyEntity> ItemPolicies { get; set; }
        public DbSet<ItemBorrowStatusEntity> ItemBorrowStatuses { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<EmployeeTypeEntity> EmployeeTypes { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<TransactionPaymentEntity> TransactionPayments { get; set; }
        public DbSet<TransactionPaymentTypeEntity> TransactionPaymentTypes { get; set; }
        public DbSet<TransactionTypeEntity> TransactionTypes { get; set; }
        public DbSet<ContactInfoEntity> ContactInfos { get; set; }


        public LibraryInventoryDbContext(DbContextOptions<LibraryInventoryDbContext> options, IUserContext userContext)
            : base(options)
        {
            _userContext = userContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var trackable = (BaseEntity)entityEntry.Entity;

                var userId = _userContext.UserId;

                if (userId.IsNullOrEmpty())
                {
                    throw new SecurityTokenException("User Id is not set.");
                }

                if (entityEntry.State == EntityState.Added)
                {
                    trackable.CreatedBy = userId!;
                    trackable.CreatedDate = DateTime.Now;
                }

                trackable.ModifiedBy = userId!;
                trackable.ModifiedDate = DateTime.Now;
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            var updatedEntries = ChangeTracker.Entries().Where(e => e.Entity is EmployeeEntity || e.Entity is MemberEntity);

            foreach (var entityEntry in updatedEntries)
            {
                if (entityEntry.Entity is EmployeeEntity employee)
                {
                    if (employee.EmployeeId == null)
                    {
                        employee.EmployeeId = employee.EmployeeKeyId.ToString();
                        entityEntry.State = EntityState.Modified;
                    }
                }
                else if (entityEntry.Entity is MemberEntity member)
                {
                    if (member.MemberId == null)
                    {
                        member.MemberId = member.MemberKeyId.ToString();
                        entityEntry.State = EntityState.Modified;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

