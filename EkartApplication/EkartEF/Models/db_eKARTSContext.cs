using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EkartEF.Models
{
    public partial class db_eKARTSContext : IdentityDbContext
    {
        public db_eKARTSContext()
        {
        }

        public db_eKARTSContext(DbContextOptions<db_eKARTSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ANKET-GI\\SQLEXPRESS;Initial Catalog=db_eKARTS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for primary key requried error while adding identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.AppCustomerId)
                    .HasMaxLength(450)
                    .HasColumnName("AppCustomerID");

                entity.Property(e => e.CustomerEmailId)
                    .HasMaxLength(100)
                    .HasColumnName("CustomerEmailID");

                entity.Property(e => e.CustomerMobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CustomerMobileNO")
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerName).HasMaxLength(30);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("CustomerAddress");

                entity.Property(e => e.CustomerAddressId).HasColumnName("CustomerAddressID");

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StName).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(30);
               
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerA__Custo__47DBAE45");
            });

            object p = modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus() { OrderStatusId = 1001, OrderStatusType = "Order Received", Description = "Order Hase been Recevied" },
                new OrderStatus() { OrderStatusId = 1002, OrderStatusType = "Order Picked", Description = "Your Order Picked from Vendor" },
                new OrderStatus() { OrderStatusId = 1003, OrderStatusType = "Order Shipped", Description = "Order shipped from nearnest wearhouse" },
                new OrderStatus() { OrderStatusId = 1004, OrderStatusType = "Out for Delivery", Description = "Your Order is Out for Delivery" },
                new OrderStatus() { OrderStatusId = 1005, OrderStatusType = "Order Deliverd", Description = "Order Has been Deliverd" }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
