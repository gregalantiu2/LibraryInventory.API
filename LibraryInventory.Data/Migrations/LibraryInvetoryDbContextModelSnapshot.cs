﻿// <auto-generated />
using System;
using LibraryInventory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryInventory.Data.Migrations
{
    [DbContext(typeof(LibraryInventoryDbContext))]
    partial class LibraryInvetoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryInventory.Data.Entities.Item.ItemFineOccurenceTypeEntity", b =>
                {
                    b.Property<int>("ItemFineOccurenceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemFineOccurenceTypeId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemFineOccurenceTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemFineOccurenceTypeId");

                    b.ToTable("ItemFineOccurenceType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Item.ItemTypeProperties", b =>
                {
                    b.Property<int>("ItemTypePropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypePropertyId"));

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypePropertyId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("ItemTypeProperties");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", b =>
                {
                    b.Property<int>("ItemBorrowStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemBorrowStatusId"));

                    b.Property<DateTime?>("CheckedOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueBack")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FineAmountAccrued")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("MemberKeyId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RenewedCount")
                        .HasColumnType("int");

                    b.HasKey("ItemBorrowStatusId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("MemberKeyId");

                    b.ToTable("ItemBorrowStatus");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemEntity", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ItemActive")
                        .HasColumnType("bit");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemPolicyId")
                        .HasColumnType("int");

                    b.Property<string>("ItemTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemPolicyId");

                    b.HasIndex("ItemTypeId");

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

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FineAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ItemFineOccurenceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ItemPolicyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaxRenewalsAllowed")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemPolicyId");

                    b.HasIndex("ItemFineOccurenceTypeId");

                    b.ToTable("ItemPolicy");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemTypeEntity", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypeId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemTypeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.EmployeeEntity", b =>
                {
                    b.Property<int>("EmployeeKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeKeyId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeKeyId");

                    b.HasIndex("ContactInfoId");

                    b.HasIndex("EmployeeTypeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.EmployeeTypeEntity", b =>
                {
                    b.Property<int>("EmployeeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeTypeId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeTypeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeTypeId");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.MemberEntity", b =>
                {
                    b.Property<int>("MemberKeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberKeyId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FineAmountOwed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MemberId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberKeyId");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Shared.ContactInfoEntity", b =>
                {
                    b.Property<int>("ContactInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactInfoId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ContactInfoId");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("ItemId");

                    b.HasIndex("MemberId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionPaymentEntity", b =>
                {
                    b.Property<int>("TransactionPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionPaymentId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionPaymentTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionPaymentId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("TransactionPaymentTypeId");

                    b.ToTable("TransactionPayment");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionPaymentTypeEntity", b =>
                {
                    b.Property<int>("TransactionPaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionPaymentTypeId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionPaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("TransactionPaymentTypeId");

                    b.ToTable("TransactionPaymentType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionTypeEntity", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionTypeId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionTypeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Item.ItemTypeProperties", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemTypeEntity", "ItemType")
                        .WithMany("ItemTypeProperties")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemEntity", "Item")
                        .WithOne("ItemBorrowStatus")
                        .HasForeignKey("LibraryInventory.Data.Entities.ItemBorrowStatusEntity", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInventory.Data.Entities.Person.MemberEntity", "Member")
                        .WithMany()
                        .HasForeignKey("MemberKeyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemPolicyEntity", "ItemPolicy")
                        .WithMany("Item")
                        .HasForeignKey("ItemPolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInventory.Data.Entities.ItemTypeEntity", "ItemType")
                        .WithMany("Item")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemPolicy");

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemPolicyEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.Item.ItemFineOccurenceTypeEntity", "ItemFineOccurenceType")
                        .WithMany()
                        .HasForeignKey("ItemFineOccurenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemFineOccurenceType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.EmployeeEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.Shared.ContactInfoEntity", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInventory.Data.Entities.Person.EmployeeTypeEntity", "EmployeeType")
                        .WithMany("Employee")
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInfo");

                    b.Navigation("EmployeeType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.MemberEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.Shared.ContactInfoEntity", "ContactInfo")
                        .WithMany()
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.ItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("LibraryInventory.Data.Entities.Person.MemberEntity", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("LibraryInventory.Data.Entities.TransactionTypeEntity", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Member");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionPaymentEntity", b =>
                {
                    b.HasOne("LibraryInventory.Data.Entities.TransactionEntity", "Transaction")
                        .WithMany("TransactionPayments")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInventory.Data.Entities.TransactionPaymentTypeEntity", "TransactionPaymentType")
                        .WithMany()
                        .HasForeignKey("TransactionPaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");

                    b.Navigation("TransactionPaymentType");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemEntity", b =>
                {
                    b.Navigation("ItemBorrowStatus");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemPolicyEntity", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.ItemTypeEntity", b =>
                {
                    b.Navigation("Item");

                    b.Navigation("ItemTypeProperties");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.Person.EmployeeTypeEntity", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LibraryInventory.Data.Entities.TransactionEntity", b =>
                {
                    b.Navigation("TransactionPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
