﻿// <auto-generated />
using System;
using LibraryInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    [DbContext(typeof(LibraryInventoryDbContext))]
    [Migration("20250202174200_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryInventory.Data.Entities.Item.ItemDetailEntity", b =>
                {
                    b.Property<int>("ItemDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemDetailId"));

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ItemTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.HasKey("ItemDetailId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("ItemTypeId")
                        .IsUnique();

                    b.ToTable("ItemDetail");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", b =>
                {
                    b.Property<int>("ItemBorrowStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemBorrowStatusId"));

                    b.Property<DateTime?>("CheckedOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueBack")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCheckedOut")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("RenewedCount")
                        .HasColumnType("int");

                    b.HasKey("ItemBorrowStatusId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("ItemBorrowStatus");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemEntity", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemPolicyEntity", b =>
                {
                    b.Property<int>("ItemPolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemPolicyId"));

                    b.Property<bool>("AllowedToCheckout")
                        .HasColumnType("bit");

                    b.Property<int>("CheckoutDays")
                        .HasColumnType("int");

                    b.Property<decimal>("FineAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FineOccurrence")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MaxRenewalsAllowed")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemPolicyId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("ItemPolicy");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemTypeEntity", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypeId"));

                    b.Property<string>("AdditionalProperties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Item.ItemDetailEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemEntity", "Item")
                        .WithOne("ItemDetail")
                        .HasForeignKey("LibraryInventory.Data.Entities.Item.ItemDetailEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInventory.Data.Entities.ItemTypeEntity", "ItemType")
                        .WithOne("ItemDetail")
                        .HasForeignKey("LibraryInventory.Data.Entities.Item.ItemDetailEntity", "ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemEntity", "Item")
                        .WithOne("ItemBorrowStatus")
                        .HasForeignKey("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemPolicyEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemEntity", "Item")
                        .WithOne("ItemPolicy")
                        .HasForeignKey("LibraryInventory.Data.Entities.ItemPolicyEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemEntity", b =>
                {
                    b.Navigation("ItemBorrowStatus");

                    b.Navigation("ItemDetail");

                    b.Navigation("ItemPolicy");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemTypeEntity", b =>
                {
                    b.Navigation("ItemDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
