using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CiberProject.Models.Entity
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R346NSM;Database=Ciber;Trusted_Connection=True; encrypt=true;trustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(350);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderName).HasMaxLength(250);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("fk_customer");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("fk_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(350);

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("fk_category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
