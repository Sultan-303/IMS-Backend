using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IMS.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSContext>
    {
        public IMSContext CreateDbContext(string[] args)
{
    var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
    
    if (string.IsNullOrEmpty(connectionString))
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.Development.json", optional: true)
            .Build();
            
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    Console.WriteLine("\n=== DESIGN TIME CONFIGURATION ===");
    Console.WriteLine($"Using DATABASE_URL: {!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE_URL"))}");
    Console.WriteLine($"Connection String Found: {!string.IsNullOrEmpty(connectionString)}");
    Console.WriteLine("===============================\n");

    var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
    optionsBuilder.UseNpgsql(connectionString);

    return new IMSContext(optionsBuilder.Options, null);
}
    }
}