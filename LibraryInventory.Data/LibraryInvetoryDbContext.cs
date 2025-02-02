using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data
{
    public class LibraryInvetoryDbContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<ItemDetailEntity> ItemDetails { get; set; }
        public DbSet<ItemPolicyEntity> ItemPolicies { get; set; }
        public DbSet<ItemBorrowStatusEntity> ItemBorrowStatuses { get; set; }

        public LibraryInvetoryDbContext(DbContextOptions<LibraryInvetoryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

