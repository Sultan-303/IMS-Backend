using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace IMS.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IMSContext>
{
    public IMSContext CreateDbContext(string[] args)
    {
        Console.WriteLine("\n=== DESIGN TIME FACTORY DEBUG ===");
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL") 
            ?? configuration.GetConnectionString("DefaultConnection");

        Console.WriteLine($"DATABASE_URL found: {!string.IsNullOrEmpty(databaseUrl)}");
        
        if (string.IsNullOrEmpty(databaseUrl))
        {
            throw new InvalidOperationException("No connection string found in DATABASE_URL or appsettings");
        }

        var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
        optionsBuilder
            .UseNpgsql(databaseUrl)
            .ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        Console.WriteLine($"Connection string configured: {databaseUrl}");
        Console.WriteLine("===================================\n");

        return new IMSContext(optionsBuilder.Options, configuration);
    }
}
}