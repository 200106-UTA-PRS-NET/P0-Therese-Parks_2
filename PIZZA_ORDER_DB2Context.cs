using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaOrder.Domain
{
    public partial class PIZZA_ORDER_DB2Context : DbContext
    {
        public PIZZA_ORDER_DB2Context()
        {
        }

        public PIZZA_ORDER_DB2Context(DbContextOptions<PIZZA_ORDER_DB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress04;Database=PIZZA_ORDER_DB2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONE_NUMBER")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.LoginId).HasColumnName("LOGIN_ID");

                entity.Property(e => e.LoginName)
                    .HasColumnName("LOGIN_NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPasscode).HasColumnName("LOGIN_PASSCODE");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__ORDERS__460A946495857A2F");

                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.CusCustomerId).HasColumnName("CUS_CUSTOMER_ID");

                entity.Property(e => e.StoreStoreId).HasColumnName("STORE_STORE_ID");

                entity.HasOne(d => d.CusCustomer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CusCustomerId)
                    .HasConstraintName("FK__ORDERS__CUS_CUST__3D5E1FD2");

                entity.HasOne(d => d.StoreStore)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreStoreId)
                    .HasConstraintName("FK__ORDERS__STORE_ST__3C69FB99");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("PIZZA");

                entity.Property(e => e.PizzaId).HasColumnName("PIZZA_ID");

                entity.Property(e => e.Cost).HasColumnName("COST");

                entity.Property(e => e.CrustType)
                    .HasColumnName("CRUST_TYPE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrderOrderId).HasColumnName("ORDER_ORDER_ID");

                entity.Property(e => e.PizzaSize)
                    .HasColumnName("PIZZA_SIZE")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaType)
                    .HasColumnName("PIZZA_TYPE")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("STORE");

                entity.Property(e => e.StoreId)
                    .HasColumnName("STORE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .HasColumnName("LOCATION")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .HasColumnName("STORE_NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
