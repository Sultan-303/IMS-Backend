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
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        Console.WriteLine("\n=== DESIGN TIME FACTORY DEBUG ===");
        Console.WriteLine($"DATABASE_URL found: {!string.IsNullOrEmpty(databaseUrl)}");
        
        if (string.IsNullOrEmpty(databaseUrl))
        {
            throw new InvalidOperationException("DATABASE_URL environment variable is not set");
        }

        var optionsBuilder = new DbContextOptionsBuilder<IMSContext>();
        optionsBuilder
            .UseNpgsql(databaseUrl)
            .ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", databaseUrl}
            })
            .Build();

        Console.WriteLine($"Connection string configured: {databaseUrl}");
        Console.WriteLine("===================================\n");

        return new IMSContext(optionsBuilder.Options, configuration);
    }
    }
}