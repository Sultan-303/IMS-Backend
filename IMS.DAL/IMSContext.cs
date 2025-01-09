using IMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

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

        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") 
            ?? _configuration?.GetConnectionString("DefaultConnection");

        if (!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
        .Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure string properties to use text type
            modelBuilder.Entity<Item>()
                .Property(i => i.ItemName)
                .HasColumnType("text");

            modelBuilder.Entity<Item>()
                .Property(i => i.Unit)
                .HasColumnType("text");

            // Specify precision and scale for the Price property
            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasColumnType("text");

            // Configure ArrivalDate and ExpiryDate properties for Stock
            modelBuilder.Entity<Stock>()
                .Property(s => s.ArrivalDate)
                .IsRequired();

            modelBuilder.Entity<Stock>()
                .Property(s => s.ExpiryDate)
                .IsRequired(false);

            // Configure the relationship between Stock and Item
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Item)
                .WithMany(i => i.Stocks)
                .HasForeignKey(s => s.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the many-to-many relationship between Item and Category
            modelBuilder.Entity<ItemCategory>()
                .HasKey(ic => new { ic.ItemID, ic.CategoryID });

            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.ItemCategories)
                .HasForeignKey(ic => ic.ItemID);

            modelBuilder.Entity<ItemCategory>()
                .HasOne(ic => ic.Category)
                .WithMany(c => c.ItemCategories)
                .HasForeignKey(ic => ic.CategoryID);

            // Configure User string properties
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

            // Configure one-to-many relationship between User and Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

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

            // Seed Items
            modelBuilder.Entity<Item>().HasData(
                // Admin's Items
                new Item
                {
                    ItemID = 1,
                    ItemName = "Admin Near Expiry Item 1",
                    Unit = "pcs",
                    Description = "Admin item nearing expiry",
                    Price = 20.99m,
                    StockQuantity = 15,
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(5), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    Category = "Electronics",
                    UserId = 1
                },
                new Item
                {
                    ItemID = 2,
                    ItemName = "Admin Low Stock Item 1",
                    Unit = "pcs",
                    Description = "Admin item with low stock",
                    Price = 5.99m,
                    StockQuantity = 3, // Low Stock
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(30),
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    Category = "Office Supplies",
                    UserId = 1
                },
                new Item
                {
                    ItemID = 3,
                    ItemName = "Admin Near Expiry & Low Stock Item",
                    Unit = "boxes",
                    Description = "Admin item near expiry and low stock",
                    Price = 15.99m,
                    StockQuantity = 2, // Low Stock
                    MinimumStockQuantity = 5,
                    ExpiryDate = DateTime.UtcNow.AddDays(4), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    Category = "Food",
                    UserId = 1
                },
                new Item
                {
                    ItemID = 4,
                    ItemName = "Admin Near Expiry Item 2",
                    Unit = "pcs",
                    Description = "Another admin item nearing expiry",
                    Price = 12.99m,
                    StockQuantity = 20,
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(6), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    Category = "Garden Supplies",
                    UserId = 1
                },
                new Item
                {
                    ItemID = 5,
                    ItemName = "Admin Low Stock Item 2",
                    Unit = "pcs",
                    Description = "Another admin item with low stock",
                    Price = 7.99m,
                    StockQuantity = 4, // Low Stock
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(25),
                    CreatedAt = DateTime.UtcNow.AddDays(-3),
                    Category = "Cleaning Supplies",
                    UserId = 1
                },

                // TestUser's Items
                new Item
                {
                    ItemID = 6,
                    ItemName = "TestUser Near Expiry Item 1",
                    Unit = "pcs",
                    Description = "TestUser item nearing expiry",
                    Price = 18.99m,
                    StockQuantity = 25,
                    MinimumStockQuantity = 15,
                    ExpiryDate = DateTime.UtcNow.AddDays(3), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-8),
                    Category = "Electronics",
                    UserId = 2
                },
                new Item
                {
                    ItemID = 7,
                    ItemName = "TestUser Low Stock Item 1",
                    Unit = "pcs",
                    Description = "TestUser item with low stock",
                    Price = 9.99m,
                    StockQuantity = 2, // Low Stock
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(20),
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    Category = "Office Supplies",
                    UserId = 2
                },
                new Item
                {
                    ItemID = 8,
                    ItemName = "TestUser Near Expiry & Low Stock Item",
                    Unit = "boxes",
                    Description = "TestUser item near expiry and low stock",
                    Price = 14.99m,
                    StockQuantity = 1, // Low Stock
                    MinimumStockQuantity = 5,
                    ExpiryDate = DateTime.UtcNow.AddDays(2), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    Category = "Food",
                    UserId = 2
                },
                new Item
                {
                    ItemID = 9,
                    ItemName = "TestUser Near Expiry Item 2",
                    Unit = "pcs",
                    Description = "Another TestUser item nearing expiry",
                    Price = 11.99m,
                    StockQuantity = 30,
                    MinimumStockQuantity = 20,
                    ExpiryDate = DateTime.UtcNow.AddDays(7), // Near Expiry
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    Category = "Garden Supplies",
                    UserId = 2
                },
                new Item
                {
                    ItemID = 10,
                    ItemName = "TestUser Low Stock Item 2",
                    Unit = "pcs",
                    Description = "Another TestUser item with low stock",
                    Price = 8.99m,
                    StockQuantity = 5, // Low Stock
                    MinimumStockQuantity = 10,
                    ExpiryDate = DateTime.UtcNow.AddDays(22),
                    CreatedAt = DateTime.UtcNow.AddDays(-9),
                    Category = "Cleaning Supplies",
                    UserId = 2
                }
            );
        }
    }
}