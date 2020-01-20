using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TPizzaBox.Client.Entities
{
    public partial class TPizzaBoxContext : DbContext
    {
        public TPizzaBoxContext()
        {
        }

        public TPizzaBoxContext(DbContextOptions<TPizzaBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<LoginTable> LoginTable { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaStore> PizzaStore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress04;Database=TPizzaBox;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.First)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaStoreId).HasColumnName("PizzaStoreID");

                entity.HasOne(d => d.PizzaStore)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PizzaStoreId)
                    .HasConstraintName("FK_Cus_PizzaStoreID");
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF42F6CD3C");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PizzaStoreId).HasColumnName("PizzaStoreID");

                entity.HasOne(d => d.PizzaStore)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaStoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Ord_PizzaStoreID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaCrust)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaSize)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaStoreId).HasColumnName("PizzaStoreID");

                entity.Property(e => e.PizzaType)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.PizzaStore)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.PizzaStoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pizza_PizzaStoreID");
            });

            modelBuilder.Entity<PizzaStore>(entity =>
            {
                entity.Property(e => e.PizzaStoreId).HasColumnName("PizzaStoreID");

                entity.Property(e => e.PizzaStoreLocation)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaStoreName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
