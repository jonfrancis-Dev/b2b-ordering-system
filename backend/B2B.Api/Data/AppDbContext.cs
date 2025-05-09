using System;
using Microsoft.EntityFrameworkCore;
using B2B.Api.Entities;

namespace B2B.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Store> Stores => Set<Store>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Store
            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("stores", schema: "production");

                entity.HasKey(s => s.Id)
                      .HasName("pk_store_id");

                entity.Property(s => s.Id).HasColumnName("store_id");
                entity.Property(s => s.Name).HasColumnName("store_name");
                entity.Property(s => s.Address).HasColumnName("store_address");
                entity.Property(s => s.ContactEmail).HasColumnName("store_contact_email");
                entity.Property(s => s.PhoneNumber).HasColumnName("store_phone_number");

                entity.HasIndex(s => s.Name).HasDatabaseName("idx_store_name");
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories", schema: "production");

                entity.HasKey(c => c.Id)
                      .HasName("pk_category_id");

                entity.Property(c => c.Id).HasColumnName("category_id");
                entity.Property(c => c.Name).HasColumnName("category_name");
                entity.Property(c => c.Description).HasColumnName("category_description");

                entity.HasIndex(c => c.Name).HasDatabaseName("idx_category_name");
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", schema: "production");

                entity.HasKey(p => p.Id)
                      .HasName("pk_product_id");

                entity.Property(p => p.Id).HasColumnName("product_id");
                entity.Property(p => p.Name).HasColumnName("product_name");
                entity.Property(p => p.Brand).HasColumnName("product_brand");
                entity.Property(p => p.Sku).HasColumnName("product_sku");
                entity.Property(p => p.Description).HasColumnName("product_description");
                entity.Property(p => p.Price).HasColumnName("product_price");
                entity.Property(p => p.StockQuantity).HasColumnName("product_stock_quantity");
                entity.Property(p => p.IsActive).HasColumnName("product_is_active");
                entity.Property(p => p.ImageUrl).HasColumnName("product_image_url");

                // Foreign Keys
                entity.Property(p => p.CategoryId).HasColumnName("category_id");
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .HasConstraintName("fk_product_category_id");

                entity.Property(p => p.StoreId).HasColumnName("store_id");
                entity.HasOne(p => p.Store)
                      .WithMany(s => s.Products)
                      .HasForeignKey(p => p.StoreId)
                      .HasConstraintName("fk_product_store_id");

                // Indexes
                entity.HasIndex(p => p.Sku)
                      .HasDatabaseName("idx_product_sku");

                entity.HasIndex(p => p.CategoryId)
                      .HasDatabaseName("idx_product_category_id");

                entity.HasIndex(p => p.StoreId)
                      .HasDatabaseName("idx_product_store_id");
            });



            // Seed Store
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Name = "Wholesale Central",
                    Address = "123 Commerce Rd",
                    ContactEmail = "info@wholesalecentral.com",
                    PhoneNumber = "555-1234"
                }
            );

            // Seed Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic gadgets and devices"
                }
            );

            // Seed Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Brand = "LogiTech",
                    Sku = "LOG-MSE-001",
                    Description = "Ergonomic wireless mouse",
                    Price = 24.99m,
                    StockQuantity = 100,
                    IsActive = true,
                    ImageUrl = "https://example.com/mouse.jpg",
                    CategoryId = 1,
                    StoreId = 1
                }
            );
        }
}
