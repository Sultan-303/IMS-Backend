using IMS.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.DAL
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

    if (!optionsBuilder.IsConfigured)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
        Console.WriteLine($"Database Connection String: {connectionString}");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("DATABASE_URL environment variable is not set");
        }
        
        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }
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

            // Seed admin user
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
        }
    }
}