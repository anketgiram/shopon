﻿// <auto-generated />
using System;
using EkartEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EkartEF.Migrations
{
    [DbContext(typeof(db_eKARTSContext))]
    [Migration("20221003042542_initOrderDetails")]
    partial class initOrderDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EkartEF.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppCustomerId")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("AppCustomerID");

                    b.Property<string>("CustomerEmailId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CustomerEmailID");

                    b.Property<string>("CustomerMobileNo")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("CustomerMobileNO")
                        .IsFixedLength(true);

                    b.Property<string>("CustomerName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EkartEF.Models.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerAddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("StName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("State")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CustomerAddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAddress");
                });

            modelBuilder.Entity("EkartEF.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientOrderId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExceptedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderAmount")
                        .HasColumnType("float");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orderd");
                });

            modelBuilder.Entity("EkartEF.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Orderid")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("Orderid");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EkartEF.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("OrderStatusType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("StatusType");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("EkartEF.Models.CustomerAddress", b =>
                {
                    b.HasOne("EkartEF.Models.Customer", "Customer")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__CustomerA__Custo__47DBAE45");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EkartEF.Models.Order", b =>
                {
                    b.HasOne("EkartEF.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EkartEF.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("EkartEF.Models.OrderItem", b =>
                {
                    b.HasOne("EkartEF.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("Orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EkartEF.Models.Customer", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("EkartEF.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
