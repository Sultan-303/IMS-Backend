using IMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;

namespace IMS.DAL
{
    public class IMSContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public IMSContext(DbContextOptions<IMSContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        // DbSet properties for each entity
        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<User> Users { get; set; }

        // Configure the database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Retrieve the connection string from environment variables or configuration
                var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                    ?? _configuration?.GetConnectionString("DefaultConnection");

                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseNpgsql(connectionString);
                }
            }

            // Suppress specific EF Core warnings
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
                         .Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
        }

        // Configure entity properties, relationships, and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================
            // Entity Property Configurations
            // ================================

            // Configure string properties to use the "text" column type in PostgreSQL
            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .HasColumnType("text");

            modelBuilder.Entity<Item>()
                .Property(i => i.Unit)
                .HasColumnType("text");

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasColumnType("text");

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasColumnType("text");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnType("text");

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasColumnType("text");

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasColumnType("text");

            // Specify precision and scale for the Price property in Item
            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            // Configure ArrivalDate and ExpiryDate properties for Stock
            modelBuilder.Entity<Stock>()
                .Property(s => s.ArrivalDate)
                .IsRequired();

            modelBuilder.Entity<Stock>()
                .Property(s => s.ExpiryDate)
                .IsRequired(false);

            // ================================
            // Relationship Configurations
            // ================================

            // Configure the relationship between Stock and Item (Many-to-One)
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Item)
                .WithMany(i => i.Stocks)
                .HasForeignKey(s => s.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the many-to-many relationship between Item and Category via ItemCategory
            modelBuilder.Entity<ItemCategory>()
                .HasKey(ic => new { ic.ItemID, ic.CategoryID });

            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.ItemCategory)
                .HasForeignKey(ic => ic.ItemID);

            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Category)
                .WithMany(c => c.ItemCategory)
                .HasForeignKey(ic => ic.CategoryID);

            // Configure the one-to-many relationship between User and Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.User)
                .WithMany(u => u.Stocks)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================================
            // Seed Data
            // ================================

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@ims.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    Username = "testuser",
                    Email = "test@ims.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Test123!"),
                    Role = "User",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }
            );

            // Seed Categories for Admin (UserId = 1)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Electronics", UserId = 1 },
                new Category { Id = 2, CategoryName = "Office Supplies", UserId = 1 },
                new Category { Id = 3, CategoryName = "Food", UserId = 1 },
                new Category { Id = 4, CategoryName = "Garden Supplies", UserId = 1 },
                new Category { Id = 5, CategoryName = "Cleaning Supplies", UserId = 1 }
            );

            // Seed Categories for TestUser (UserId = 2)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 6, CategoryName = "Electronics", UserId = 2 },
                new Category { Id = 7, CategoryName = "Office Supplies", UserId = 2 },
                new Category { Id = 8, CategoryName = "Food", UserId = 2 },
                new Category { Id = 9, CategoryName = "Garden Supplies", UserId = 2 },
                new Category { Id = 10, CategoryName = "Cleaning Supplies", UserId = 2 }
            );

            // Seed Items for Admin (UserId = 1)
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemID = 1,
                    Name = "Admin Near Expiry Item 1",
                    Unit = "pcs",
                    Description = "Admin item nearing expiry",
                    Price = 20.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UserId = 1
                },
                new Item
                {
                    ItemID = 2,
                    Name = "Admin Low Stock Item 1",
                    Unit = "pcs",
                    Description = "Admin item with low stock",
                    Price = 5.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UserId = 1
                },
                new Item
                {
                    ItemID = 3,
                    Name = "Admin Near Expiry & Low Stock Item",
                    Unit = "boxes",
                    Description = "Admin item near expiry and low stock",
                    Price = 15.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    UserId = 1
                },
                new Item
                {
                    ItemID = 4,
                    Name = "Admin Near Expiry Item 2",
                    Unit = "pcs",
                    Description = "Another admin item nearing expiry",
                    Price = 12.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    UserId = 1
                },
                new Item
                {
                    ItemID = 5,
                    Name = "Admin Low Stock Item 2",
                    Unit = "pcs",
                    Description = "Another admin item with low stock",
                    Price = 7.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    UserId = 1
                }
            );

            // Seed Items for TestUser (UserId = 2)
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemID = 6,
                    Name = "TestUser Near Expiry Item 1",
                    Unit = "pcs",
                    Description = "TestUser item nearing expiry",
                    Price = 18.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    UserId = 2
                },
                new Item
                {
                    ItemID = 7,
                    Name = "TestUser Low Stock Item 1",
                    Unit = "pcs",
                    Description = "TestUser item with low stock",
                    Price = 9.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    UserId = 2
                },
                new Item
                {
                    ItemID = 8,
                    Name = "TestUser Near Expiry & Low Stock Item",
                    Unit = "boxes",
                    Description = "TestUser item near expiry and low stock",
                    Price = 14.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    UserId = 2
                },
                new Item
                {
                    ItemID = 9,
                    Name = "TestUser Near Expiry Item 2",
                    Unit = "pcs",
                    Description = "Another TestUser item nearing expiry",
                    Price = 11.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    UserId = 2
                },
                new Item
                {
                    ItemID = 10,
                    Name = "TestUser Low Stock Item 2",
                    Unit = "pcs",
                    Description = "Another TestUser item with low stock",
                    Price = 8.99m,
                    CreatedAt = DateTime.UtcNow.AddDays(-9),
                    UserId = 2
                }
            );

            // Seed ItemCategory (Associating Items with Categories)
            modelBuilder.Entity<ItemCategory>().HasData(
                // Admin's Items Associations
                new ItemCategory { ItemID = 1, CategoryID = 1 }, // Electronics
                new ItemCategory { ItemID = 2, CategoryID = 2 }, // Office Supplies
                new ItemCategory { ItemID = 3, CategoryID = 3 }, // Food
                new ItemCategory { ItemID = 4, CategoryID = 4 }, // Garden Supplies
                new ItemCategory { ItemID = 5, CategoryID = 5 }, // Cleaning Supplies

                // TestUser's Items Associations
                new ItemCategory { ItemID = 6, CategoryID = 6 }, // Electronics
                new ItemCategory { ItemID = 7, CategoryID = 7 }, // Office Supplies
                new ItemCategory { ItemID = 8, CategoryID = 8 }, // Food
                new ItemCategory { ItemID = 9, CategoryID = 9 }, // Garden Supplies
                new ItemCategory { ItemID = 10, CategoryID = 10 } // Cleaning Supplies
            );
        }
    }
}