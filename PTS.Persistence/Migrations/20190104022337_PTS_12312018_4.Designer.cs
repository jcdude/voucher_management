﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PTS.Persistence;

namespace PTS.Persistence.Migrations
{
    [DbContext(typeof(PTSDbContext))]
    [Migration("20190104022337_PTS_12312018_4")]
    partial class PTS_12312018_4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PTS.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.Property<Guid>("ExternalId");

                    b.Property<byte[]>("Picture");

                    b.Property<int>("SupplierId");

                    b.HasKey("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Country");

                    b.Property<Guid>("ExternalId");

                    b.Property<DateTime>("ExternalIdExpiry");

                    b.Property<string>("Fax");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<string>("Username");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Extension");

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("HireDate");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<int?>("ManagerEmployeeId");

                    b.Property<string>("Notes");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("PhotoPath");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.Property<int?>("ReportsTo");

                    b.Property<string>("Title");

                    b.Property<string>("TitleOfCourtesy");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerEmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<int?>("CustomerId1");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<DateTime?>("RequiredDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PTS.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Discount");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<short>("Quantity");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("ProductName");

                    b.Property<string>("QuantityPerUnit");

                    b.Property<short?>("ReorderLevel");

                    b.Property<int?>("SupplierId");

                    b.Property<decimal?>("UnitPrice");

                    b.Property<short?>("UnitsInStock");

                    b.Property<short?>("UnitsOnOrder");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Pin");

                    b.Property<int>("StockId");

                    b.Property<bool>("Used");

                    b.HasKey("ServiceId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StockId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Pin");

                    b.Property<int>("ProductId");

                    b.Property<bool>("Used");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Country");

                    b.Property<Guid>("ExternalId");

                    b.Property<string>("Fax");

                    b.Property<string>("HomePage");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Region");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Category", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Categories")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PTS.Domain.Entities.Employee", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Employee", "Manager")
                        .WithMany("DirectReports")
                        .HasForeignKey("ManagerEmployeeId");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Order", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("PTS.Domain.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("PTS.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PTS.Domain.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PTS.Domain.Entities.Product", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("PTS.Domain.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("PTS.Domain.Entities.Service", b =>
                {
                    b.HasOne("PTS.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PTS.Domain.Entities.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
