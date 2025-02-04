using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data
{
    public class LibraryInventoryDbContext : DbContext
    {
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


        public LibraryInventoryDbContext(DbContextOptions<LibraryInventoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

