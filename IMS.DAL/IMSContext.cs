using IMS.Common.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify precision and scale for the Price property
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

            // Configure the relationship between Stock and Item
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Item)                // Specify the navigation property
                .WithMany(i => i.Stocks)            // Specify the collection navigation
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

            // Seed admin user
            modelBuilder.Entity<User>().HasData(new User
            {
              Id = 1,
              Username = "admin",
              Email = "admin@ims.com",
              PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
              Role = "Admin",
              CreatedAt = DateTime.UtcNow
            });
        }
    }
}